using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;

namespace MAS_Sustainability.Controllers
{
    public class TokenController : Controller
    {

        

        [HttpGet]
        // GET: Token
        public ActionResult Index()
        {
            MainModel finalItem = new MainModel();
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "UserLogin");
            }

            DB dbConn = new DB();
            DataTable dtblTokens = new DataTable();
            DataTable userDetailsDataTable = new DataTable();
            DataTable ForwardedTokeDataTable = new DataTable();
            MainModel mainModel = new MainModel();

            Token tokenModel = new Token();

            List<UserLogin> List_UserLogin = new List<UserLogin>();
            List<Token> List_Token = new List<Token>();
            List<Token> Token_List = new List<Token>();


            using (MySqlConnection mySqlCon = dbConn.DBConnection())
            {
                mySqlCon.Open();
                string qry = "SELECT tka.TokenAuditID,tk.ProblemName,tk.Location,tk.AttentionLevel,usr.UserName,tkFlow.TokenManagerStatus FROM users usr,tokens tk, token_audit tka,token_flow tkFlow WHERE tk.TokenAuditID = tka.TokenAuditID AND tka.AddedUser = usr.UserEmail AND tk.TokenAuditID = tkFlow.TokenAuditID";  
                MySqlDataAdapter mySqlDA = new MySqlDataAdapter(qry,mySqlCon);
                mySqlDA.Fill(dtblTokens);



                String qry_forwared_tokens = "SELECT tka.TokenAuditID,tk.ProblemName,tk.Location,tk.AttentionLevel,usr.UserName,tkFlow.TokenManagerStatus,tkreview.SentUser " +
                    "FROM users usr,tokens tk, token_audit tka,token_flow tkFlow, token_review tkreview " +
                    "WHERE tk.TokenAuditID = tka.TokenAuditID AND tka.AddedUser = usr.UserEmail AND tk.TokenAuditID = tkFlow.TokenAuditID AND tk.TokenAuditID = tkreview.TokenAuditID";

                MySqlDataAdapter mySqlDAForwardedTokens = new MySqlDataAdapter(qry_forwared_tokens,mySqlCon);
                mySqlDAForwardedTokens.Fill(ForwardedTokeDataTable);



                String qry_listOfTokens = "SELECT UserName,UserType,UserID,UserEmail,UserImage FROM users WHERE UserEmail = '" + Session["user"] + "'";
                MySqlDataAdapter mySqlDa = new MySqlDataAdapter(qry_listOfTokens, mySqlCon);
                mySqlDa.Fill(userDetailsDataTable);
                //DashbordController dashbord = new DashbordController();
                //finalItem.LoggedUserName = dashbord.setUserDetails().ToString();

            }

            for (int i = 0; i < dtblTokens.Rows.Count; i++)
            {
 
                List_Token.Add(new Token
                    { ProblemName = dtblTokens.Rows[i][1].ToString(),
                      Location = dtblTokens.Rows[i][2].ToString(),
                      AttentionLevel = Convert.ToInt32(dtblTokens.Rows[i][3]) ,
                      UserName = dtblTokens.Rows[i][4].ToString() ,
                      TokenStatus = dtblTokens.Rows[i][5].ToString(),
                      TokenAuditID = Convert.ToInt32(dtblTokens.Rows[i][0]),
                      //SentUser = dtblTokens.Rows[i][6].ToString()
                     }                                  
                );

            }

            for(int i = 0; i < ForwardedTokeDataTable.Rows.Count; i++)
            {
                Token_List.Add(new Token
                {
                    ProblemName = ForwardedTokeDataTable.Rows[i][1].ToString(),
                    Location = ForwardedTokeDataTable.Rows[i][2].ToString(),
                    AttentionLevel = Convert.ToInt32(ForwardedTokeDataTable.Rows[i][3]),
                    UserName = ForwardedTokeDataTable.Rows[i][4].ToString(),
                    TokenStatus = ForwardedTokeDataTable.Rows[i][5].ToString(),
                    TokenAuditID = Convert.ToInt32(ForwardedTokeDataTable.Rows[i][0]),
                    SentUser = ForwardedTokeDataTable.Rows[i][6].ToString()

                }
                );
            }

            if (userDetailsDataTable.Rows.Count == 1)
            {
                mainModel.LoggedUserName = userDetailsDataTable.Rows[0][0].ToString();
                mainModel.LoggedUserType = userDetailsDataTable.Rows[0][1].ToString();
                mainModel.LoggedUserID = Convert.ToInt32(userDetailsDataTable.Rows[0][2]);
                mainModel.LoggedUserEmail = userDetailsDataTable.Rows[0][3].ToString();
                mainModel.UserImagePath = userDetailsDataTable.Rows[0][4].ToString();
            }


            mainModel.ListToken = List_Token;
            mainModel.ListUserLogin = List_UserLogin;
            mainModel.TokenList = Token_List;

            return View(mainModel);
        }

        // GET: Token/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Token/Create
        public ActionResult Add()
        {
            DB dbConn = new DB();
            DataTable userDetailsDataTable = new DataTable();
            MainModel mainModel = new MainModel();
            using (MySqlConnection mySqlCon = dbConn.DBConnection())
            {
                String qry_listOfTokens = "SELECT UserName,UserType,UserID,UserImage FROM users WHERE UserEmail = '" + Session["user"] + "'";
                MySqlDataAdapter mySqlDa = new MySqlDataAdapter(qry_listOfTokens, mySqlCon);
                mySqlDa.Fill(userDetailsDataTable);
            }

            if (userDetailsDataTable.Rows.Count == 1)
            {
                mainModel.LoggedUserName = userDetailsDataTable.Rows[0][0].ToString();
                mainModel.LoggedUserType = userDetailsDataTable.Rows[0][1].ToString();
                mainModel.LoggedUserID = Convert.ToInt32(userDetailsDataTable.Rows[0][2]);
                mainModel.UserImagePath = userDetailsDataTable.Rows[0][3].ToString();
            }


            return View(mainModel);
        }

        // POST: Token/Create
        [HttpPost]
        public ActionResult Add(Token tokenModel)
        {

        
            DataTable userDetailsDataTable = new DataTable();
            MainModel mainModel = new MainModel();



            //Image 01
            string first_name_of_file = Path.GetFileNameWithoutExtension(tokenModel.FirstImageFile.FileName);
            string extension1 = Path.GetExtension(tokenModel.FirstImageFile.FileName);
            first_name_of_file = first_name_of_file + DateTime.Now.ToString("yymmssfff") +extension1;
            tokenModel.FirstImagePath = "~/Image/" +first_name_of_file;
            first_name_of_file = Path.Combine(Server.MapPath("~/Image/"), first_name_of_file);
            tokenModel.FirstImageFile.SaveAs(first_name_of_file);

            String imgPath1 = tokenModel.FirstImagePath;



            //Image 02
            string second_name_of_file = Path.GetFileNameWithoutExtension(tokenModel.SecondImageFile.FileName);
            string extension2 = Path.GetExtension(tokenModel.SecondImageFile.FileName);
            second_name_of_file = second_name_of_file + DateTime.Now.ToString("yymmssfff") + extension2;
            tokenModel.SecondImagePath = "~/Image/" + second_name_of_file;
            second_name_of_file = Path.Combine(Server.MapPath("~/Image/"), second_name_of_file);
            tokenModel.SecondImageFile.SaveAs(second_name_of_file);

            String imgPath2 = tokenModel.SecondImagePath;




            String AddedUser = Session["user"].ToString();


            DB dbConn = new DB();
            using (MySqlConnection mySqlCon = dbConn.DBConnection())
            {

                mySqlCon.Open();
                // String qry = "INSERT INTO token_audit(AddedUser,Category,AddedDate)VALUES(@AddedUser,@Category,NOW())";



                MySqlCommand mySqlCmd_TokenAudit = new MySqlCommand("Proc_Store_TokenAudit", mySqlCon);
                mySqlCmd_TokenAudit.CommandType = CommandType.StoredProcedure;
                mySqlCmd_TokenAudit.Parameters.AddWithValue("_Category", tokenModel.ProblemCategory);
                mySqlCmd_TokenAudit.Parameters.AddWithValue("_AddedUser", AddedUser);


                mySqlCmd_TokenAudit.ExecuteNonQuery();


                String last_audit_id_qry = "SELECT TokenAuditID FROM token_audit ORDER BY TokenAuditID DESC LIMIT 1";
                MySqlDataAdapter mySqlDA = new MySqlDataAdapter(last_audit_id_qry, mySqlCon);
                DataTable dt = new DataTable();
                mySqlDA.Fill(dt);

                int last_audit_id_num = Convert.ToInt32(dt.Rows[0][0]);

                string qry = "INSERT INTO tokens(TokenAuditID,ProblemName,Location,AttentionLevel,Description) VALUES(@TokenAuditID,@ProblemName,@Location,@AttentionLevel,@Description)";

                MySqlCommand mySqlCmd_tokenInfo = new MySqlCommand(qry, mySqlCon);
                mySqlCmd_tokenInfo.Parameters.AddWithValue("@TokenAuditID", last_audit_id_num);
                mySqlCmd_tokenInfo.Parameters.AddWithValue("@ProblemName", tokenModel.ProblemName);
                mySqlCmd_tokenInfo.Parameters.AddWithValue("@Location", tokenModel.Location);
                mySqlCmd_tokenInfo.Parameters.AddWithValue("@AttentionLevel", tokenModel.AttentionLevel);
                mySqlCmd_tokenInfo.Parameters.AddWithValue("@Description", tokenModel.Description);
                mySqlCmd_tokenInfo.ExecuteNonQuery();


                MySqlCommand mySqlCmd_ImageUpload = new MySqlCommand("Proc_Store_Images", mySqlCon);
                mySqlCmd_ImageUpload.CommandType = CommandType.StoredProcedure;
                mySqlCmd_ImageUpload.Parameters.AddWithValue("_TokenAuditID", last_audit_id_num);
                mySqlCmd_ImageUpload.Parameters.AddWithValue("_ImgPath1", imgPath1);
                mySqlCmd_ImageUpload.Parameters.AddWithValue("_ImgPath2", imgPath2);
                mySqlCmd_ImageUpload.ExecuteNonQuery();



                String qryTokenStatus = "INSERT INTO token_flow(TokenAuditID,TokenManagerStatus,DeptLeaderStatus,FinalVerification) values(@TokenAuditID,'Pending','Pending','Pending')";
                MySqlCommand mySqlCmd_tokenStatus = new MySqlCommand(qryTokenStatus,mySqlCon);
                mySqlCmd_tokenStatus.Parameters.AddWithValue("@TokenAuditID", last_audit_id_num);
                mySqlCmd_tokenStatus.ExecuteNonQuery();

              

            }
            // TODO: Add insert logic here
         

            return View();
        }



        // GET: Token/Edit/5
        public ActionResult View(int id)
        {
            MainModel mainModel = new MainModel();

            Token tokenModel1 = new Token();
            DataTable dtblToken = new DataTable();
            DataTable dtblSideList = new DataTable();

            DataTable dtblTokenImage = new DataTable();

            DataTable userDetailsDataTable = new DataTable();
            String AddedUser = Session["user"].ToString();

            DB dbConn = new DB();
            using (MySqlConnection mySqlCon = dbConn.DBConnection())
            {
                mySqlCon.Open();

                String qry = "SELECT tka.TokenAuditID,tk.ProblemName,tka.AddedDate,tk.Location,tk.AttentionLevel,usr.UserName,tki.ImagePath,tk.Description FROM users usr,tokens tk, token_audit tka,token_image tki WHERE tk.TokenAuditID = tka.TokenAuditID AND tka.AddedUser = usr.UserEmail AND tk.TokenAuditID = tki.TokenID AND tk.TokenAuditID = @TokenAuditID ";
                MySqlDataAdapter mySqlDa = new MySqlDataAdapter(qry, mySqlCon);
                mySqlDa.SelectCommand.Parameters.AddWithValue("@TokenAuditID", id);
                mySqlDa.Fill(dtblToken);


                String qry_side_token_list = "SELECT tka.TokenAuditID,tk.ProblemName,tk.Location,tk.AttentionLevel,tki.ImagePath FROM tokens tk, token_audit tka,token_image tki WHERE tk.TokenAuditID = tka.TokenAuditID  AND tk.TokenAuditID = tki.TokenID";
                MySqlDataAdapter mySqlDa_sideList = new MySqlDataAdapter(qry_side_token_list, mySqlCon);
                mySqlDa_sideList.Fill(dtblSideList);



                String qry_listOfTokens = "SELECT UserName,UserType,UserID,UserImage FROM users WHERE UserEmail = '" + Session["user"] + "'";
                MySqlDataAdapter mySqlData = new MySqlDataAdapter(qry_listOfTokens, mySqlCon);
                mySqlData.Fill(userDetailsDataTable);


                mainModel.ArrTokenAuditID = new int[50];
                 mainModel.ArrProblemName = new string[250];
                 mainModel.ArrLocation = new string[100];
                 mainModel.ArrAttentionLevel = new int[200000];
                 mainModel.ArrFirstImagePath = new string[500];

                 mainModel.no_of_rows_side_bar = Convert.ToInt32(dtblSideList.Rows.Count);

            

            }

            for (int i = 0; i < dtblSideList.Rows.Count; i = i + 2)
            {

                 mainModel.ArrTokenAuditID[i] = Convert.ToInt32(dtblSideList.Rows[i][0]);
                 mainModel.ArrProblemName[i] = dtblSideList.Rows[i][1].ToString();
                 mainModel.ArrLocation[i] = dtblSideList.Rows[i][2].ToString();
                 mainModel.ArrAttentionLevel[i] = Convert.ToInt32(dtblSideList.Rows[i][3]);
                 mainModel.ArrFirstImagePath[i] = dtblSideList.Rows[i][4].ToString();

            }



            if (dtblToken.Rows.Count == 2 )
            {
                mainModel.TokenAuditID = Convert.ToInt32(dtblToken.Rows[0][0]);
                 mainModel.ProblemName = dtblToken.Rows[0][1].ToString();
                 mainModel.AddedDate = dtblToken.Rows[0][2].ToString();
                 mainModel.Location = dtblToken.Rows[0][3].ToString();
                 mainModel.AttentionLevel = Convert.ToInt32(dtblToken.Rows[0][4]);
                 mainModel.UserName = dtblToken.Rows[0][5].ToString();
                 mainModel.FirstImagePath = dtblToken.Rows[0][6].ToString();
                 mainModel.SecondImagePath = dtblToken.Rows[1][6].ToString();
                 mainModel.Description = dtblToken.Rows[0][7].ToString();

                mainModel.LoggedUserName = userDetailsDataTable.Rows[0][0].ToString();
                mainModel.LoggedUserType = userDetailsDataTable.Rows[0][1].ToString();
                mainModel.LoggedUserID = Convert.ToInt32(userDetailsDataTable.Rows[0][2]);
                mainModel.UserImagePath = userDetailsDataTable.Rows[0][3].ToString();

                ViewBag.TokenVariable = mainModel;
                return View(mainModel);

            }
            else
            {
                return View("Index");
            }



        }

        // POST: Token/Edit/5
        [HttpPost]
        public ActionResult TokenForward(Token tokenModel)
        {
            DB dbConn = new DB();
            String ForwardUser = Session["user"].ToString();
            using (MySqlConnection mySqlCon = dbConn.DBConnection())
            {

                mySqlCon.Open();
                string qry = "INSERT INTO token_review(TokenAuditID,SpecialActs,RepairDepartment,SentDate,SentUser)VALUES(@TokenAuditID,@SpecialActs,@ReparationDepartment,NOW(),@SentUser)";
                MySqlCommand mySqlCmd_TokenFoward = new MySqlCommand(qry, mySqlCon);
                mySqlCmd_TokenFoward.Parameters.AddWithValue("@TokenAuditID", tokenModel.TokenAuditID);
                mySqlCmd_TokenFoward.Parameters.AddWithValue("@SpecialActs", "Urgent");
                mySqlCmd_TokenFoward.Parameters.AddWithValue("@ReparationDepartment", tokenModel.ReparationDepartment);
                mySqlCmd_TokenFoward.Parameters.AddWithValue("@SentUser",ForwardUser);
                mySqlCmd_TokenFoward.ExecuteNonQuery();

                String update_token_status = "UPDATE token_flow SET TokenManagerStatus = @ReparationDepartment WHERE TokenAuditID = @TokenAuditID";

                MySqlCommand mySqlCommand_update_token_status = new MySqlCommand(update_token_status,mySqlCon);
                mySqlCommand_update_token_status.Parameters.AddWithValue("@TokenAuditID", tokenModel.TokenAuditID);
                mySqlCommand_update_token_status.Parameters.AddWithValue("@ReparationDepartment", tokenModel.ReparationDepartment);
                mySqlCommand_update_token_status.ExecuteNonQuery();

                return RedirectToAction("index");

            }


        }

        // GET: Token/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Token/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        public ActionResult Update(Token tokenModel)
        {
            DB dbConn = new DB();
            String ForwardUser = Session["user"].ToString();

            using (MySqlConnection mySqlCon = dbConn.DBConnection())
            {
                mySqlCon.Open();
                /*String qry_update_dept_token_flow = "UPDATE token_flow SET TokenManagerStatus = @ReparationDepartment WHERE TokenAuditID = @TokenAuditID";
                MySqlCommand mySqlCmd_update_dept_token_flow = new MySqlCommand(qry_update_dept_token_flow, mySqlCon);
                mySqlCmd_update_dept_token_flow.Parameters.AddWithValue("@ReparationDepartment", tokenModel.TokenAuditID);
                mySqlCmd_update_dept_token_flow.Parameters.AddWithValue("@TokenAuditID", tokenModel.ReparationDepartment);
                mySqlCmd_update_dept_token_flow.ExecuteNonQuery();
                */
                String update_token_status_token_flow = "UPDATE token_flow SET TokenManagerStatus = @ReparationDepartment WHERE TokenAuditID = @TokenAuditID";

                MySqlCommand mySqlCommand_update_token_status_token_flow = new MySqlCommand(update_token_status_token_flow, mySqlCon);
                mySqlCommand_update_token_status_token_flow.Parameters.AddWithValue("@TokenAuditID", tokenModel.TokenAuditID);
                mySqlCommand_update_token_status_token_flow.Parameters.AddWithValue("@ReparationDepartment", tokenModel.ReparationDepartment);
                mySqlCommand_update_token_status_token_flow.ExecuteNonQuery();



                String update_token_status_token_review = "UPDATE token_review SET RepairDepartment = @ReparationDepartment,SentDate = NOW() WHERE TokenAuditID = @TokenAuditID ";
                MySqlCommand mySqlCmd_update_token_status_token_review = new MySqlCommand(update_token_status_token_review,mySqlCon);
                mySqlCmd_update_token_status_token_review.Parameters.AddWithValue("@TokenAuditID", tokenModel.TokenAuditID);
                mySqlCmd_update_token_status_token_review.Parameters.AddWithValue("@ReparationDepartment", tokenModel.ReparationDepartment);
                mySqlCmd_update_token_status_token_review.ExecuteNonQuery();




                return RedirectToAction("Index");
            }



           
        }


        public ActionResult MyTokens()
        {

            MainModel finalItem = new MainModel();
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "UserLogin");
            }

            DB dbConn = new DB();
            DataTable dtblTokens = new DataTable();
            DataTable userDetailsDataTable = new DataTable();
            DataTable ForwardedTokeDataTable = new DataTable();
            MainModel mainModel = new MainModel();

            Token tokenModel = new Token();

            List<UserLogin> List_UserLogin = new List<UserLogin>();
            List<Token> List_Token = new List<Token>();
            List<Token> Token_List = new List<Token>();

            using (MySqlConnection mySqlCon = dbConn.DBConnection())
            {

                mySqlCon.Open();
                String qry_myTokens = "SELECT tka.TokenAuditID,tka.Category,usr.UserName,tka.AddedDate,tk.ProblemName,tk.Location,tk.AttentionLevel,tkf.TokenManagerStatus " +
                    "FROM mas_isscs.token_audit tka,mas_isscs.tokens tk,mas_isscs.token_flow tkf,mas_isscs.users usr WHERE " +
                    "tka.TokenAuditID = tk.TokenAuditID  and tka.TokenAuditID = tkf.TokenAuditID AND " +
                    "tka.AddedUser = '" + Session["user"] + "' and tka.AddedUser = usr.UserEmail";

                MySqlDataAdapter mySqlDA = new MySqlDataAdapter(qry_myTokens, mySqlCon);
                mySqlDA.Fill(dtblTokens);


                String qry_UserDetails = "SELECT UserName,UserType,UserID,UserEmail,UserImage FROM users WHERE UserEmail = '" + Session["user"] + "'";
                MySqlDataAdapter mySqlDataUserDetails = new MySqlDataAdapter(qry_UserDetails, mySqlCon);
                mySqlDataUserDetails.Fill(userDetailsDataTable);


            }
            if (userDetailsDataTable.Rows.Count == 1)
            {
                mainModel.LoggedUserName = userDetailsDataTable.Rows[0][0].ToString();
                mainModel.LoggedUserType = userDetailsDataTable.Rows[0][1].ToString();
                mainModel.LoggedUserID = Convert.ToInt32(userDetailsDataTable.Rows[0][2]);
                mainModel.LoggedUserEmail = userDetailsDataTable.Rows[0][3].ToString();
                mainModel.UserImagePath = userDetailsDataTable.Rows[0][4].ToString();
            }

            for (int i = 0; i < dtblTokens.Rows.Count; i++)
            {

                List_Token.Add(new Token
                {
                    ProblemName = dtblTokens.Rows[i][4].ToString(),
                    ProblemCategory = dtblTokens.Rows[i][1].ToString(),
                    Location = dtblTokens.Rows[i][5].ToString(),
                    AttentionLevel = Convert.ToInt32(dtblTokens.Rows[i][6]),
                    UserName = dtblTokens.Rows[i][2].ToString(),
                    TokenStatus = dtblTokens.Rows[i][7].ToString(),
                    TokenAuditID = Convert.ToInt32(dtblTokens.Rows[i][0]),
                    AddedDate = dtblTokens.Rows[i][3].ToString()
                    //SentUser = dtblTokens.Rows[i][6].ToString()
                }
                );

            }

            mainModel.ListToken = List_Token;
            mainModel.ListUserLogin = List_UserLogin;
            mainModel.TokenList = Token_List;


            return View(mainModel);
        }

        public ActionResult TokenUpdate(int id)
        {
            DataTable userDetailsDataTable = new DataTable();

            List<UserLogin> List_UserLogin = new List<UserLogin>();
            List<Token> Token_List = new List<Token>();
            List<Token> List_Token = new List<Token>();

            DataTable dtblTokens = new DataTable();
            MainModel mainModel = new MainModel();
            DB dbConn = new DB();

            using (MySqlConnection mySqlCon = dbConn.DBConnection())
            {
                mySqlCon.Open();
                String qry_UserDetails = "SELECT UserName,UserType,UserID,UserEmail,UserImage FROM users WHERE UserEmail = '" + Session["user"] + "'";
                MySqlDataAdapter mySqlDataUserDetails = new MySqlDataAdapter(qry_UserDetails, mySqlCon);
                mySqlDataUserDetails.Fill(userDetailsDataTable);

                String qry_myTokens = "SELECT tka.TokenAuditID,tka.Category,usr.UserName,tka.AddedDate,tk.ProblemName,tk.Location,tk.AttentionLevel,tkf.TokenManagerStatus,tkimg.ImagePath,tk.description " +
                "FROM token_audit tka,tokens tk,token_flow tkf,users usr,token_image tkimg WHERE " +
                "tka.TokenAuditID = tk.TokenAuditID AND tkf.TokenManagerStatus = 'Pending' and tka.TokenAuditID = tkf.TokenAuditID AND " +
                "tka.AddedUser = '" + Session["user"] + "' and tka.AddedUser = usr.UserEmail and tka.TokenAuditID = @TokenAuditID and tkimg.TokenID = tk.TokenAuditID";

                MySqlDataAdapter mySqlData_TokenInfo = new MySqlDataAdapter(qry_myTokens, mySqlCon);
                mySqlData_TokenInfo.SelectCommand.Parameters.AddWithValue("@TokenAuditID", id);
                mySqlData_TokenInfo.Fill(dtblTokens);

            }

            if (userDetailsDataTable.Rows.Count == 1)
            {
                mainModel.LoggedUserName = userDetailsDataTable.Rows[0][0].ToString();
                mainModel.LoggedUserType = userDetailsDataTable.Rows[0][1].ToString();
                mainModel.LoggedUserID = Convert.ToInt32(userDetailsDataTable.Rows[0][2]);
                mainModel.LoggedUserEmail = userDetailsDataTable.Rows[0][3].ToString();
                mainModel.UserImagePath = userDetailsDataTable.Rows[0][4].ToString();
            }

            if (dtblTokens.Rows.Count == 2)
            {

                mainModel.FirstImagePath = dtblTokens.Rows[0][8].ToString();
                mainModel.SecondImagePath = dtblTokens.Rows[1][8].ToString();

                List_Token.Add(new Token
                {
                    ProblemName = dtblTokens.Rows[0][4].ToString(),
                    ProblemCategory = dtblTokens.Rows[0][1].ToString(),
                    Location = dtblTokens.Rows[0][5].ToString(),
                    AttentionLevel = Convert.ToInt32(dtblTokens.Rows[0][6]),
                    UserName = dtblTokens.Rows[0][2].ToString(),
                    TokenStatus = dtblTokens.Rows[0][7].ToString(),
                    TokenAuditID = Convert.ToInt32(dtblTokens.Rows[0][0]),
                    AddedDate = dtblTokens.Rows[0][3].ToString(),
                    Description = dtblTokens.Rows[0][9].ToString()

                }
                );
            }

            mainModel.ListToken = List_Token;
            mainModel.TokenList = Token_List;

            return View(mainModel);
        }


        public ActionResult DoUpdateProcess(Token tokenModel)
        {
            DB dbConn = new DB();

            using (MySqlConnection mySqlCon = dbConn.DBConnection())
            {

                mySqlCon.Open();

                String update_token_details = "UPDATE tokens tk,token_audit tka SET tk.ProblemName = @ProblemName,tk.Location = @Location,tka.Category = @ProblemCategory  WHERE tka.TokenAuditID = tk.TokenAuditID and tka.TokenAuditID = @TokenAuditID";
                MySqlCommand mySqlCommand_update_token_status = new MySqlCommand(update_token_details, mySqlCon);
                mySqlCommand_update_token_status.Parameters.AddWithValue("@Description",tokenModel.Description);
                mySqlCommand_update_token_status.Parameters.AddWithValue("@TokenAuditID",tokenModel.TokenAuditID);
                mySqlCommand_update_token_status.Parameters.AddWithValue("@ProblemName", tokenModel.ProblemName);
                mySqlCommand_update_token_status.Parameters.AddWithValue("@Location", tokenModel.Location);
                mySqlCommand_update_token_status.Parameters.AddWithValue("@ProblemCategory", tokenModel.ProblemCategory);

      


                mySqlCommand_update_token_status.ExecuteNonQuery();

            }


            return RedirectToAction("MyTokens");
        }

        public ActionResult DoUpdateProcessInDetail(Token tokenModel)
        {
            DB dbConn = new DB();

            using (MySqlConnection mySqlCon = dbConn.DBConnection())
            {

                mySqlCon.Open();
               

                String update_token_details = "UPDATE tokens tk,token_audit tka SET tk.AttentionLevel = @AttentionLevel, tk.Description = @Description,tk.ProblemName = @ProblemName,tk.Location = @Location,tka.Category = @ProblemCategory  WHERE tka.TokenAuditID = tk.TokenAuditID and tka.TokenAuditID = @TokenAuditID";

                MySqlCommand mySqlCommand_update_token_status = new MySqlCommand(update_token_details, mySqlCon);
                mySqlCommand_update_token_status.Parameters.AddWithValue("@TokenAuditID", tokenModel.TokenAuditID);
                mySqlCommand_update_token_status.Parameters.AddWithValue("@ProblemName", tokenModel.ProblemName);
                mySqlCommand_update_token_status.Parameters.AddWithValue("@Location", tokenModel.Location);
                mySqlCommand_update_token_status.Parameters.AddWithValue("@ProblemCategory", tokenModel.ProblemCategory);

                mySqlCommand_update_token_status.Parameters.AddWithValue("@AttentionLevel", tokenModel.AttentionLevel);
                mySqlCommand_update_token_status.Parameters.AddWithValue("@Description", tokenModel.Description);


                mySqlCommand_update_token_status.ExecuteNonQuery();

            }


            return RedirectToAction("MyTokens");
        }


    }
}
