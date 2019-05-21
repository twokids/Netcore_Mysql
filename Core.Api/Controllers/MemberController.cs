using Core.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core.api.Controllers
{
    [Produces("application/json")]
    [Route("api/admin/[controller]")]
    [ApiController]
    public class MemberController : Controller
    {

        private readonly CoreContext _context;
        public MemberController(CoreContext context)
        {
            _context = context;
        }
        #region base

        /// <summary>
        /// 获取单个
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public JsonResult GetById(int id)
        {
            var tt = _context.Set<Member>().Where(c => c.id == id).ToList();
            //_context.Set<Member>().Add(us);
            //_context.SaveChanges();
            return Json(tt);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Add(Member entity = null)
        {
            _context.Set<Member>().Add(entity);
            int num = _context.SaveChanges();

            if (entity == null)
                return Json("参数为空");
            if (num > 0) { return Json("成功"); }
            else { return Json("失敗"); }
        }
        /// <summary>
        /// 编辑 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Member")]
        public JsonResult Update(Member entity = null)
        {

            _context.Set<Member>().Update(entity);
            int num = _context.SaveChanges();
            if (entity == null)
                return Json("参数为空");
            if (num > 0) { return Json("成功"); }
            else { return Json("失敗"); }
        }

        /// <summary>
        /// 删除 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete]
        public JsonResult Dels(int[] ids = null)
        {
            if (ids.Length == 0)
                return Json("参数为空");
            var tt = _context.Set<Member>().Where(c => ids.Contains(c.id)).First();
            _context.Set<Member>().Remove(tt);
            int num = _context.SaveChanges();
            if (num > 0) { return Json("成功"); }
            else { return Json("失敗"); }
        }
        #endregion
    }
}