using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelFinder.Entites
{
    public class Hotel
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)] //şurada demek istediğimiz Id alanı Key yani birincil anahtar olacak ve identiy birden başlayıp artacak.
        public int Id { get; set; }
        [StringLength(50)] //uzunluğu 50 karakter olmalı dedik. 
        public string Name { get; set; }
        [StringLength(50)]
        public string City { get; set; }
    }
}
