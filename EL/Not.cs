using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EL
{
    public class Not: INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        string id, not;
        public string ID
        {
            get
            {
                if (id == null)
                    id = Guid.NewGuid().ToString();
                return id;
            }
            set { id = value; }
        }

        //public string Resim  => "person.png";

        public string Nots
        {
            get { return not; }
            set
            {
                not = value;
                NotifyPropertyChanged();
            }
        }


    }
}
