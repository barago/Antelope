using Antelope.Models;
using Antelope.Models.HSE;
using Antelope.Models.Socle;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using System.Web.Security;
using System.Diagnostics;
using Antelope.Services.HSE.Enums;




namespace Antelope
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            GlobalConfiguration.Configure(WebApiConfig.Register);

            //Datas Initializer when the base is in a Create/Drop state
            //Database.SetInitializer<AntelopeContext>(new AntelopeContextInitializer());
            Database.SetInitializer(new TestContextInitializer());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Session_Start()
        {

            AntelopeContext db = new AntelopeContext();
            HSERoleEnum HSERole = HSERoleEnum.Visiteur;
            HSERoleEnum CurrentHSERole = HSERoleEnum.Visiteur;

            var allADRoleMapped = from a in db.ADRoles
                                  where a.RoleType == "HSE"
                                  select a;

            foreach (ADRole ADRole in allADRoleMapped)
            {

                Debug.WriteLine(ADRole.Name);

                var id = ClaimsPrincipal.Current.Identities.First();
                string[] roles = Roles.GetRolesForUser(id.Name);

                if (Roles.IsUserInRole(ADRole.Name.Replace(@"\\", @"\")))
                {
                    Debug.WriteLine(ADRole.Name);

                    HSERoleEnum RoleToAdd = (HSERoleEnum)Enum.Parse(typeof(HSERoleEnum), ADRole.RoleCode);  //TODO : Renommer RoleCode en APPRoleCode !!! RoleType en APPRoleType

                    if ((Int32)RoleToAdd < (Int32)HSERole)
                    {
                        HSERole = RoleToAdd;
                        CurrentHSERole = RoleToAdd;
                    }

                }

            }

            Session["HSERole"] = Enum.GetName(typeof(HSERoleEnum), HSERole);
            Session["CurrentHSERole"] = Enum.GetName(typeof(HSERoleEnum), CurrentHSERole);

        }


        void Application_AcquireRequestState()
        {

            //String HSERole = Session["HSERole"] as String;
            //var id = ClaimsPrincipal.Current.Identities.First();
            //Boolean IsInRole = Roles.IsUserInRole(HSERole);

            //id.AddClaim(new Claim(ClaimTypes.GroupSid, HSERole));
            //Boolean IsInRole2 = Roles.IsUserInRole(HSERole);

            //var e = 5;

        }


        void Application_PostAuthenticateRequest()
        {

            if (Request.IsAuthenticated)
            {


                //var HSERole = Session["HSERole"];

                //var id = ClaimsPrincipal.Current.Identities.First();
                //string[] roles = Roles.GetRolesForUser(id.Name);
                //Boolean IsInRole = Roles.IsUserInRole("Tartampion");

                //id.AddClaim(new Claim(ClaimTypes.GroupSid, "Tartampion"));
                //Boolean IsInRole2 = Roles.IsUserInRole("Tartampion");

                //string[] roles2 = Roles.GetRolesForUser(id.Name);
                //int a = 1;

                //var util = User.Identity.Name;
                //User.Identity.   AddClaim(new Claim(ClaimTypes.Role, "Tartampion"));
                //foreach (var role in roles)
                //{
                //Console.WriteLine("Role : " + role);
                //id.Claims.add(new Claim(ClaimTypes.Role, role));
                //int c = 3;
                //var id2 = new ClaimsIdentity();
                //id2.AddClaim(new Claim(ClaimTypes.Role, "YourRole"));
                //ClaimsPrincipal.Current.AddIdentity(id);
                //string[] roles3 = Roles.GetRolesForUser();
                //Roles.AddUserToRole(User.Identity.Name, "AGAGAGAGAGAGAGAGAGAGAG");
                //string[] roles3 = Roles.GetRolesForUser(User.Identity.Name);
                //string[] rolesId = Roles.GetRolesForUser(User.Identity.Name);
                //int d = 4;
                //}
            }
        }
    }
}
