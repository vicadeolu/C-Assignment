using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace BusinessLogicLayer.IServices
{
    public interface ITagServices
    {
        /// <summary>
        ///     Get tag object
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Category object</returns>
        Tags? GetTags(int id);

        /// <summary>
        ///    Get tag by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Tags? GetTagByName(string name);


        /// <summary>
        ///     Get all tag in the database
        /// </summary>
        /// <returns>List of Category Object</returns>
        List<Tags> GetAllTags();

        /// <summary>
        ///     Remove a Tag
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteTags(int id, out string message);


        /// <summary>
        ///     Modify a Tag object
        /// </summary>
        /// <param name="tag"></param>
        /// <returns>Uodated Object</returns>
        Tags? UpdateTags(Tags tags, out string message);


        /// <summary>
        ///     Create a Tag
        /// </summary>
        /// <param name="tag"></param>
        /// <returns>Create a new Category object</returns>
        Tags? CreateTag(Tags tags, out string message);
    }
}
