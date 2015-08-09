using System;
using System.Web.Mvc;
using AutoMapper;
using ChuanYu.TA.Domain.Common;
using ChuanYu.TA.Domain.Services;
using ChuanYu.TA.Entity.Enums;
using ChuanYu.TA.Entity.User;
using ChuanYu.TA.MvcApp.Common;
using ChuanYu.TA.MvcApp.Models;
using ChuanYu.TA.MvcApp.Models.User;
using Sys.Common;

namespace ChuanYu.TA.MvcApp.Controllers
{
    [ResourceFilter]
    public class UserController : Controller
    {
        //
        // GET: /User/
        #region 实例化对象
        /// <summary>
        /// 用户类对象
        /// </summary>
        private readonly Lazy<CyUserService> _userService = new Lazy<CyUserService>();
        public CyUserService CyUserService
        {
            get
            {
                return _userService.Value;
            }
        }
        #endregion
        public ActionResult RegistInfo()
        {
            CommonMethod.SetMenuChecked("sideRegister");
 
            return View();
        }
        public ActionResult Register()
        {
            CommonMethod.SetMenuChecked("sideRegister");

            return View();
        }

        public ActionResult AddCompany()
        {
            return View();
        }

        public ActionResult UserDetail()
        {
            CommonMethod.SetMenuChecked("sideUserInfo");
            var user = new CyUser();
            var userNo = UserContext.CurrentUser.UserNo;
            if (string.IsNullOrEmpty(userNo))
            {
                 return RedirectToAction("Login","Login");
            }
            var model = CyUserService.GetCyUserByNo(userNo).ResultObj;
            if (model != null)
            {
                user = Mapper.Map<CyUserEntity, CyUser>(model);
                user.GenderName = EnumHelper.GetEnumDescription(user.Gender);
                user.IndustryName = EnumHelper.GetEnumDescription(user.Industry);
            }

            return View(user);
        }

        public ActionResult CompanyDetail()
        {
            return View();
        }

        public JsonResult SubmitRegister(CyUser user)
        {
            try
            {
                CyUserEntity cyUserEntity = Mapper.Map<CyUser, CyUserEntity>(user);
                cyUserEntity.MemberType = MemberType.Normal;
                cyUserEntity.Role = Role.Normal;
                cyUserEntity.CreateUserNo = "System";
                cyUserEntity.UpdateUserNo = "System";
                if (string.IsNullOrWhiteSpace(cyUserEntity.Birthday))
                {
                    cyUserEntity.Birthday = string.Empty;
                }
                if (string.IsNullOrWhiteSpace(cyUserEntity.BirthPlace))
                {
                    cyUserEntity.BirthPlace = string.Empty;
                }
                if (string.IsNullOrWhiteSpace(cyUserEntity.Residence))
                {
                    cyUserEntity.Residence = string.Empty;
                }
                if (string.IsNullOrWhiteSpace(cyUserEntity.Position))
                {
                    cyUserEntity.Position = string.Empty;
                }

                var addResult = CyUserService.AddCyUser(cyUserEntity);
                if (addResult.Success && addResult.EffectRows > 0)
                {
                    return Json(new { IsSuccess = true });
                }
                else
                {
                    return Json(new { IsSuccess = false, ErrorInfo = addResult.ExMessage });
                }
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, ErrorInfo = ex });
            }
        }

        public JsonResult SaveUserEdit(CyUser user)
        {
            try
            {
                CyUserEntity cyUserEntity = Mapper.Map<CyUser, CyUserEntity>(user);
                if (string.IsNullOrWhiteSpace(cyUserEntity.Birthday))
                {
                    cyUserEntity.Birthday = string.Empty;
                }
                if (string.IsNullOrWhiteSpace(cyUserEntity.BirthPlace))
                {
                    cyUserEntity.BirthPlace = string.Empty;
                }
                if (string.IsNullOrWhiteSpace(cyUserEntity.Residence))
                {
                    cyUserEntity.Residence = string.Empty;
                }
                if (string.IsNullOrWhiteSpace(cyUserEntity.Position))
                {
                    cyUserEntity.Position = string.Empty;
                }
                cyUserEntity.UpdateTime = DateTime.Now;
                cyUserEntity.UpdateUserNo = UserContext.CurrentUser.UserNo ?? "System";
                var modifyResult = CyUserService.ModifyCyUser(cyUserEntity);
                if (modifyResult.Success && modifyResult.EffectRows > 0)
                {
                    return Json(new { IsSuccess = true });
                }
                else
                {
                    return Json(new { IsSuccess = false, ErrorInfo = modifyResult.ExMessage });
                }
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, ErrorInfo = ex });
            }
        }

        public JsonResult SubmitAddCompany(CyCompany company)
        {
            try
            {
                CyCompanyEntity cyCompanyEntity = Mapper.Map<CyCompany, CyCompanyEntity>(company);
                var addResult = CyUserService.AddCyCompany(cyCompanyEntity);
                if (addResult.Success && addResult.EffectRows > 0)
                {
                    return Json(new { IsSuccess = true });
                }
                else
                {
                    return Json(new { IsSuccess = false, ErrorInfo = addResult.ExMessage });
                }
            }
            catch (Exception ex)
            {

                return Json(new { IsSuccess = false, ErrorInfo = ex });
            }
        }

        public JsonResult UploadImage()
        {
            return Json(new { IsSuccess = true });
        }
    }
}
