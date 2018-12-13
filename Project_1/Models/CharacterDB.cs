using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_1.Models
{
    [Table("CharacterDB")]
    public class CharacterDB
    {
        #region Properties
        /// <summary>
        /// The unique ID of the character resource.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CharacterID { get; set; }

        /// <summary>
        /// The name of the character.
        /// </summary>
        [Required (ErrorMessage = "Name is required")]
        public string Name { get; set; }

        /// <summary>
        /// A short bio or description of the character.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The representative image for this character.
        /// </summary>
        [Required(ErrorMessage = "Image URL is required")]
        public string ThumbnailURL { get; set; }

        /// <summary>
        /// A set of public web site URLs for the resource.
        /// </summary>
        public string URL { get; set; }
        #endregion
    }
}