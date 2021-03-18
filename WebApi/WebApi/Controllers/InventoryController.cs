using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class InventoryController : ApiController
    {
        private WebApiDbModel db = new WebApiDbModel();

        public IQueryable<InventoryList> GetInventoryLists()
        {
            return db.InventoryLists;
        }

        // GET: api/Inventory/5
        [ResponseType(typeof(InventoryList))]
        public async Task<IHttpActionResult> GetInventoryList(int id)
        {
            try
            {
                var inventoryList = await db.InventoryLists.FindAsync(id);
                if (inventoryList == null)
                {
                    return NotFound();
                }

                return Ok(inventoryList);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            
        }

        // PUT: api/Inventory/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInventoryList(int id, InventoryList inventoryList)
        {
            try
            {
                if (id != inventoryList.InventoryID)
                {
                    return BadRequest();
                }

                db.Entry(inventoryList).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryListExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            
        }

        // POST: api/Inventory
        [ResponseType(typeof(InventoryList))]
        public async Task<IHttpActionResult> PostInventoryList(InventoryList inventoryList)
        {
            try
            {
                db.InventoryLists.Add(inventoryList);
                await db.SaveChangesAsync();

                return CreatedAtRoute("DefaultApi", new { id = inventoryList.InventoryID }, inventoryList);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            
        }

        // DELETE: api/Inventory/5
        [ResponseType(typeof(InventoryList))]
        public async Task<IHttpActionResult> DeleteInventoryList(int id)
        {
            try
            {
                var inventoryList = await db.InventoryLists.FindAsync(id);
                if (inventoryList == null)
                {
                    return NotFound();
                }

                db.InventoryLists.Remove(inventoryList);
                await db.SaveChangesAsync();

                return Ok(inventoryList);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
           
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            
        }

        private bool InventoryListExists(int id)
        {
            try
            {
                return db.InventoryLists.Count(e => e.InventoryID == id) > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}