using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelService _hotelService;
        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }


        [HttpGet]
        public IActionResult Get()  //public List<Hotel> Get() eski kod buydu
        {
            var hotels= _hotelService.GetAllHotels();
            return Ok(hotels); //ok yani 200 dönüyoruz. + body kısmına hotels i ekle diyoruz.
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) //public Hotel Get(int id) eski kod
        {
            var hotel = _hotelService.GetHotelById(id);
            if (hotel!=null)
            {
                return Ok(hotel); //200 + hotel datası döndü
            }
            return NotFound(); //yani 404 herhangi data gönderilmeyecek
            
        }

        [HttpPost]
        public Hotel Post([FromBody]Hotel hotel)
        {
            return _hotelService.CreateHotel(hotel);

        }
        [HttpPut]
        public Hotel Put([FromBody] Hotel hotel)
        {
            return _hotelService.UpdateHotel(hotel);

        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _hotelService.DeleteHotel(id);

        }
    }
}
