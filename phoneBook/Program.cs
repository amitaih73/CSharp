using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace phoneBook
{
    public interface IPhonebook
    {
        ContactDetails ById(int a_id);
        ContactDetails ByFullName(string a_fullName);

        int muchWithPrefix(string a_prefixPhone);


    }

    

    public class ContactDetails
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string City { get; set; }

        public List<string> Phones;

        public ReadOnlyCollection<string> getPhones()
        {
            return Phones.AsReadOnly();
        }
        public ContactDetails()
        {
            Id = 0;
            FullName = "EMPTY";
            City = "EMPTY";

        }

        public override string ToString()
        {
            string outPutStr = $"{Id}\n{FullName}\n{City}\n ";
            outPutStr += "Phones:\n";
            foreach (string phone in Phones)
            {
                outPutStr += $"{phone}\n";
            }

            return outPutStr;
        }
    }
    class PhoneBook : IPhonebook
    {
        private List<ContactDetails> _Contacts;
        public PhoneBook()
        {
            _Contacts = new List<ContactDetails>();
        }

        private ReadOnlyCollection<ContactDetails> getContacts()
        {
            return _Contacts.AsReadOnly();
        }

        public ContactDetails ById(int a_id)
        {
            return _Contacts.Find(contact => contact.Id == a_id);
        }

        public ContactDetails ByFullName(string a_fullName)
        {
            return _Contacts.Find(contact => contact.FullName == a_fullName);
        }

        public int muchWithPrefix(string a_prefixPhone)
        {
            ReadOnlyCollection<ContactDetails> contactsList = getContacts();
            int muchPrefix = 0;
            foreach (ContactDetails deatails in contactsList) {
                muchPrefix += deatails.getPhones().Count(phone => phone.StartsWith(a_prefixPhone));
            }
            return muchPrefix;
        }
        public void AddNewContactDetails(int a_id, string a_name, String a_city, List<string> a_phones)
        {
            ContactDetails NewContact = new ContactDetails();
            NewContact.Id = a_id; 
            NewContact.FullName = a_name;
            NewContact.City = a_city;
            NewContact.Phones = new List<string>(a_phones);
            _Contacts.Add(NewContact);
          
        }
    }

    
    class Test {
        static public void Main()
        {
            PhoneBook book = new PhoneBook();
            book.AddNewContactDetails(305401853, "amitai", "jerusalem", new List<string> { "05425", "05555", "05496" });
            book.AddNewContactDetails(302744885, "david", "Tel Aviv", new List<string> { "05425", "05555", "05896" });
            /*ContactDetails contact = book.ById(305401853);
            Console.WriteLine(contact.ToString());*/
            ContactDetails contact = book.ByFullName("david");
            Console.WriteLine(contact.ToString());
            int byPhone = book.muchWithPrefix("054");
            Console.WriteLine($"much phones start whith 054 is {byPhone.ToString()}");
        }
    }
}

