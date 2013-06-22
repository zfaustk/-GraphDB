using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHGraphDB.Structure.Interface
{
    /// <summary>
    /// Every object is a DBObject
    /// </summary>
    public interface IDBObject
    {

        String KHID { get; }

        /// <summary>
        /// Returns all attributes for this object
        /// </summary>
        IDictionary<String, Object> Attributes { get; } //sdasdasd

        #region Methods

        /// <summary>
        /// Gets or sets the attribute-value associated with the specified key.
        /// </summary>
        Object this[String Key] { get; set; }

        /// <summary>
        /// Removes the attribute-value with the specified key if it exists.
        /// </summary>
        /// <param name="Key">the key of the element to remove</param>
        bool RemoveAttribute(String Key);

        #endregion
    }
}
