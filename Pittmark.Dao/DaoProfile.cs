using PittmarkProject.DbMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pittmark.Dao
{
    public class DaoProfile
    {
        private PittmarkStoreEntities _daoProfile;
        public DaoProfile()
        {
            _daoProfile = new PittmarkStoreEntities();
        }
        public Profile AddProfile(Profile profile)
        {
            var result = _daoProfile.Profiles.Add(profile);
            _daoProfile.SaveChanges();
            return result;
        }
        public Email AddEmail(Email email)
        {
            var result = _daoProfile.Emails.Add(email);
            _daoProfile.SaveChanges();
            return result;
        }
        public PhoneNumber AddPhoneNumber(PhoneNumber phoneNumber)
        {
            var result = _daoProfile.PhoneNumbers.Add(phoneNumber);
            _daoProfile.SaveChanges();
            return result;
        }
        public Address AddAddress(Address address)
        {
            var result = _daoProfile.Addresses.Add(address);
            _daoProfile.SaveChanges();
            return result;
        }
        public Facebook AddFacebook(Facebook facebook)
        {
            var result = _daoProfile.Facebooks.Add(facebook);
            _daoProfile.SaveChanges();
            return result;
        }
        public void DeleteAll()
        {
            _daoProfile.Addresses.RemoveRange(_daoProfile.Addresses.AsEnumerable());
            _daoProfile.Emails.RemoveRange(_daoProfile.Emails.AsEnumerable());
            _daoProfile.Facebooks.RemoveRange(_daoProfile.Facebooks.AsEnumerable());
            _daoProfile.PhoneNumbers.RemoveRange(_daoProfile.PhoneNumbers.AsEnumerable());
            _daoProfile.Profiles.RemoveRange(_daoProfile.Profiles.AsEnumerable());
            _daoProfile.SaveChanges();
        }
    }
}
