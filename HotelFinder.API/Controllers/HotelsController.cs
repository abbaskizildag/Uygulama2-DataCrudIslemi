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
        public IActionResult Post([FromBody]Hotel hotel)
        {
            //if (ModelState.IsValid) benim yukarıdaki ApiController diye bir route var. Bu hotel.cs de reuqired olanları orada kontrol ediyor. Dolayısıyla eğer apicontroller olmasaydi modelstate.isvalid kullanırdır ama olduğu için kullanmaya gerenk yok.
            //{
                var createHotel = _hotelService.CreateHotel(hotel);
                return CreatedAtAction("Get", new { id = createHotel.Id }, createHotel); //201 + data
            //}
           // return BadRequest(ModelState); //400 +validation errors

        }
        [HttpPut]
        public IActionResult Put([FromBody] Hotel hotel)
        {
            if (_hotelService.GetHotelById(hotel.Id)!=null)
            {
                return Ok(_hotelService.UpdateHotel(hotel)); //200 responca kodu + data
            }
            return NotFound();

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_hotelService.GetHotelById(id) != null)
            {
                _hotelService.DeleteHotel(id);
                return Ok(); //200 responca kodu 
            }
            return NotFound(); 

            //_hotelService.DeleteHotel(id);

        }
    }
}
