using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP2_2
{

    public class BindingListSourceAdapter<T> : BindingSource //адаптер
    {
        public BindingListSourceAdapter(BindingList<T> original)
        {

            for (int i = 0; i < original.Count; i++)
            {
                this.Add(new Item(original, i));
            }
            original.ListChanged += (obj, args) =>
               OnListChanged(new ListChangedEventArgs(
                    args.ListChangedType, args.NewIndex));
        }
        private class Item : INotifyPropertyChanged
        {
            IList<T> source;
            int index;
            public Item(IList<T> source, int index) => (this.source, this.index) = (source, index);

            public T Value
            {
                get => source[index];
                set
                {
                    source[index] = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
        }
    }
}