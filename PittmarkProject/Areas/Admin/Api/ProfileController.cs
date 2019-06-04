using Pittmark.Dao;
using PittmarkProject.DbMain;
using PittmarkProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace PittmarkProject.Areas.Admin.Api
{
    [RoutePrefix("Api/Profile")]
    public class ProfileController : ApiController
    {
        private DaoProfile _daoProfile;
        public ProfileController()
        {
            _daoProfile = new DaoProfile();
        }
     
        [Route("Update")]
        [HttpPut]
       public HttpResponseMessage Put(HttpRequestMessage request, ProfileViewModel profileViewModel)
        {
            _daoProfile.DeleteAll();

            Profile profile = new Profile();
            List<Email> emailList = new List<Email>();
            List<PhoneNumber> phoneList = new List<PhoneNumber>();
            List<Address> addressList = new List<Address>();
            List<Facebook> facebookList = new List<Facebook>();

            profile.Img_cover = profileViewModel.ImgCover;
            profile.Img_logo = profileViewModel.ImgLogo;




            profileViewModel.EmailList.ForEach((x) =>
            {
                Email email = new Email();
                email.Name = x;
                _daoProfile.AddEmail(email);                         
            });

            profileViewModel.PhoneNumberList.ForEach((x) =>
            {
                PhoneNumber phone = new PhoneNumber();
                phone.Name = x;
                _daoProfile.AddPhoneNumber(phone);
            });

            profileViewModel.AddressList.ForEach((x) =>
            {
                Address address = new Address();
                address.Name = x;
                _daoProfile.AddAddress(address);
            });

            profileViewModel.FaceBook.ForEach((x) =>
            {
                Facebook facebook = new Facebook();
                facebook.Name = x;
                facebook.Id = 1;
                _daoProfile.AddFacebook(facebook);
            });

            _daoProfile.AddProfile(profile);

            return request.CreateResponse(HttpStatusCode.OK);
        }
    }
}