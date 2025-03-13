using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace DataAccessLayer.IRepository
{
    public interface ICommentRepository
    {

        /// <summary>
        /// Get product Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>tag Object by Id</returns>
        Comments? Get(int Id);



        /// <summary>
        /// List of tag
        /// </summary>
        /// <returns>List of tag</returns>
        List<Comments> Get();



        /// <summary>
        /// Delete tag
        /// </summary>
        /// <param name="tag"></param>
        void Delete(Comments comments);


        /// <summary>
        /// Create tag
        /// </summary>
        /// <param name="tag"></param>
        /// <returns>tag Object</returns>
        Comments Create(Comments comments);

        /// <summary>
        /// Update tag Details
        /// </summary>
        /// <param name="tag"></param>
        /// <returns>Updated Object</returns>
        Comments? Update(Comments comments);

    }
}
