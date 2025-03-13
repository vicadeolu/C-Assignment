using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.IRepository
{
    public interface ITagRepository
    {
        /// <summary>
        /// Get product Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>tag Object by Id</returns>
        Tags? Get(int id);

        Tags? Get(string name);

        /// <summary>
        /// List of tag
        /// </summary>
        /// <returns>List of tag</returns>
        List<Tags> Get();



        /// <summary>
        /// Delete tag
        /// </summary>
        /// <param name="tag"></param>
        void Delete(Tags tag);


        /// <summary>
        /// Create tag
        /// </summary>
        /// <param name="tag"></param>
        /// <returns>tag Object</returns>
        Tags Create(Tags tag);

        /// <summary>
        /// Update tag Details
        /// </summary>
        /// <param name="tag"></param>
        /// <returns>Updated Object</returns>
        Tags? Update(Tags tag);
    }
}
