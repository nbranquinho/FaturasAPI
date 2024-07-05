using Asp.Versioning;
using FaturasAPI.DB;
using FaturasAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Text;
using System.Web;

namespace FaturasAPI.Controllers
{
    /// <summary>
    /// Class that Control the invoices
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class FaturaItemsController(FaturaContext context) : ControllerBase
    {
        private readonly FaturaContext _context = context;

        // GET: api/FaturaItems
        /// <summary>
        /// Get all registered invoices
        /// </summary>
        /// <returns></returns>
        /// <response code="404">Nothing was found</response>
        /// <response code="200">All items</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<FaturaItem>>> GetFaturaItems()
        {
            if (_context.FaturaItems == null)
             {
                 return NotFound();
             }

             return await _context.FaturaItems.ToListAsync();
        }

        // GET: api/FaturaItems/5
        /// <summary>
        /// Get the invoice details
        /// </summary>
        /// <remarks>
        ///     this is a remark test
        /// </remarks>
        /// <param name="id">The invoice identification</param>
        /// <returns>Returns a <typeparamref name="FaturaItem"/> object with the details <typeparam name="FaturaItem" />  </returns>
        /// <response code="200">Returns a <typeparamref name="FaturaItem"/> object.</response>
        /// <response code="404">If the <paramref name="id"/> doesn't exits</response>
        [HttpGet("{id}")]
        [ProducesResponseType<FaturaItem>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FaturaItem>> GetFaturaItem(string id)
        {
            if (_context.FaturaItems == null)
            {
                return NotFound();
            }

            var idToFind = HttpUtility.UrlDecode(id);

            var faturaItem = await _context.FaturaItems.FindAsync(idToFind);

            if (faturaItem == null)
            {
                return NotFound();
            }

            return faturaItem;
        }

        // PUT: api/FaturaItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates the <code>FaturaItem</code>
        /// </summary>
        /// <param name="id">The invoice identification</param>
        /// <param name="faturaItem">The Object with the invoice data</param>
        /// <returns></returns>
        /// <response code="204">Update successfull</response>
        /// <response code="400">Request bad formatted/created</response>
        /// <response code="404">If the <paramref name="id"/> doesn't exits</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFaturaItem(string id, FaturaItem faturaItem)
        {
            if (id != faturaItem.G_IdentificacaoUnicaDocumento)
            {
                return BadRequest();
            }

            _context.Entry(faturaItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FaturaItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FaturaItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Save the invoice data
        /// </summary>
        /// <param name="faturaItem">The Object with the invoice data</param>
        /// <returns></returns>
        /// <response code="202">Save was successfull</response>
        /// <response code="409">The invoice <paramref name="id"/> already exits</response>
        [HttpPost]
        [ProducesResponseType<FaturaItem>(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        //[ProducesResponseType(StatusCodes.Prob)]
        public async Task<ActionResult<FaturaItem>> PostFaturaItem(FaturaItem faturaItem)
        {
            if (_context.FaturaItems == null)
            {
                return Problem("Entity set 'FaturaContext.FaturaItems'  is null.");
            }

            _context.FaturaItems.Add(faturaItem);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FaturaItemExists(faturaItem.G_IdentificacaoUnicaDocumento))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            //return CreatedAtAction("PostFaturaItem", new { id = faturaItem.G_IdentificacaoUnicaDocumento }, faturaItem);
            return Accepted();
        }

        // DELETE: api/FaturaItems/5
        /// <summary>
        /// Delete an invoice
        /// </summary>
        /// <param name="id">The invoice identification</param>
        /// <returns></returns>
        /// <response code="204">Delete successfull</response>
        /// <response code="404">The <paramref name="id"/> doesn't exits</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteFaturaItem(string id)
        {
            if (_context.FaturaItems == null)
            {
                return NotFound();
            }
            var faturaItem = await _context.FaturaItems.FindAsync(id);
            if (faturaItem == null)
            {
                return NotFound();
            }

            _context.FaturaItems.Remove(faturaItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Check if an invoice id exists
        /// </summary>
        /// <param name="id">The invoice identification</param>
        /// <returns><c>True</c> if exists, otherwise <c>False</c></returns>
        private bool FaturaItemExists(string id)
        {
            return (_context.FaturaItems?.Any(e => e.G_IdentificacaoUnicaDocumento == id)).GetValueOrDefault();
        }


        [Route("[action]")]
        [HttpGet]
        public ActionResult<string> ConnectionTeste()
        {
            //Enter your ADB's user id, password, and net service name
            string conString = "***REMOVED***;Connection Timeout=30;";

            //conString += "Data Source=***REMOVED***;";
            conString += "Data Source=***REMOVED***";
            StringBuilder output = new();

            //Enter directory where you unzipped your cloud credentials
            //OracleConfiguration.TnsAdmin = Path.Combine(Directory.GetCurrentDirectory(), "Properties/Wallet_nbranquinhoDB/");
            //OracleConfiguration.WalletLocation = OracleConfiguration.TnsAdmin;

            using OracleConnection con = new(conString);
            using OracleCommand cmd = con.CreateCommand();
            try
            {
                con.Open();
                output.AppendLine("Successfully connected to Oracle Autonomous Database");


                cmd.CommandText = "select sysdate from dual ";
                //"from SH.CUSTOMERS order by CUST_ID fetch first 20 rows only";
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    output.AppendLine($" Database time is {reader.GetOracleDate(0)}");
            }
            catch (Exception ex)
            {
                output.AppendLine(ex.Message);
            }
            finally
            {
                if (con != null && con.State != System.Data.ConnectionState.Closed) con.Close();
            }

            return Ok(output.ToString());
        }

    }
}
