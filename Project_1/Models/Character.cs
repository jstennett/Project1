using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_1.Models
{
    public class Character
    {
        #region Properties
        /// <summary>
        /// The unique ID of the character resource.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the character.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A short bio or description of the character.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The date the resource was most recently modified.
        /// </summary>
        public string Modified { get; set; }

        /// <summary>
        /// The canonical URL identifier for this resource.
        /// </summary>
        public string ResourceURI { get; set; }

        /// <summary>
        /// The representative image for this character.
        /// </summary>
        public Thumbnail Thumbnail { get; set; }

        #endregion
    }
}