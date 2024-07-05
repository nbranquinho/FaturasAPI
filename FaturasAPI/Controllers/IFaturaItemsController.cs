using FaturasAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FaturasAPI.Controllers
{
    public interface IFaturaItemsController
    {
        Task<IActionResult> DeleteFaturaItem(string id);
        Task<ActionResult<FaturaItem>> GetFaturaItem(string id);
        Task<ActionResult<IEnumerable<FaturaItem>>> GetFaturaItems();
        Task<ActionResult<FaturaItem>> PostFaturaItem(FaturaItem faturaItem);
        Task<IActionResult> PutFaturaItem(string id, FaturaItem faturaItem);
    }
}