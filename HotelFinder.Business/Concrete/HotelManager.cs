using HotelFinder.Business.Abstract;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;
using HotelFinder.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.Business.Concrete
{
    public class HotelManager : IHotelService
    {
        //implemente yaptıktan sonra bana burda hotelrepository örneği lazım
        private IHotelRepository _hotelRepository;
        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository; //eşitliyoruz
        }
        public Hotel CreateHotel(Hotel hotel)
        {
            return _hotelRepository.CreateHotel(hotel);
        }

        public void DeleteHotel(int id)
        {
             _hotelRepository.DeleteHotel(id);
        }

        public List<Hotel> GetAllHotels()
        {
            return _hotelRepository.GetAllHotels();
        }

        public Hotel GetHotelById(int id)
        {
            if (id>0)
            {
                return _hotelRepository.GetHotelById(id);
            }
            throw new Exception("id then more less 0");
        }

        public Hotel GetHotelByName(string name)
        {
            return _hotelRepository.GetHotelByName(name);
        }

        public Hotel UpdateHotel(Hotel hotel)
        {
            return _hotelRepository.UpdateHotel(hotel);
        }
    }
}
