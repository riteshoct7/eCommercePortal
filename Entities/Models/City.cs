﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities.Models
{
    public class City :BaseEntity
    {

        #region Constructors

        public City()
        {
            Enabled = true;
        }

        #endregion

        #region Fields

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CityId { get; set; }

        [Display(Name = "City Name")]
        [Required(ErrorMessage = "City Name Required")]
        public string CityName { get; set; }

        [Display(Name = "City Description")]        
        public string CityDescription { get; set; }

        [ForeignKey("State")]
        public int StateId { get; set; }

        public State State { get; set; }

        #endregion

    }
}
