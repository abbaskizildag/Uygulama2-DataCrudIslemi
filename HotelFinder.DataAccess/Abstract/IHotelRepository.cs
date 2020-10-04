using HotelFinder.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.DataAccess.Abstract
{
    public interface IHotelRepository
    {
        List<Hotel> GetAllHotels(); //list olarak alacak
        Hotel GetHotelById(int id);

        Hotel CreateHotel(Hotel hotel);
        Hotel UpdateHotel(Hotel hotel);

        void DeleteHotel(int id);

    }
}
