
#define FIREBASE


namespace DL
{
    using EL;

#if FIREBASE
    using Firebase.Database;
    using Firebase.Database.Query;
    using System.Collections.ObjectModel;
#endif
    public static class DL
    {
#if FIREBASE
        static FirebaseClient client = new FirebaseClient("https://rehber13-14cbd-default-rtdb.firebaseio.com");

        public static bool AddContact(Not n, ref string message)
        {
            client.Child($"kisiler/{n.ID}").PutAsync(n);
            return true;
        }

        public static bool EditContact(Not n, ref string message)
        {
            client.Child($"kisiler/{n.ID}").PutAsync(n);
            return true;
        }

        public static bool DeleteContact(Not n, ref string message)
        {
            client.Child($"kisiler/{n.ID}").DeleteAsync();
            return true;
        }

        public static ObservableCollection<Not> GetContacts(ref string message)
        {
            ObservableCollection<Not> kisilist = new ObservableCollection<Not>();

            var kisiler = client.Child("kisiler").OnceAsync<Not>();
            foreach (var kisi in kisiler.Result)
            {
                kisilist.Add(kisi.Object);
            }
            return kisilist;
        }
    }
}

#endif