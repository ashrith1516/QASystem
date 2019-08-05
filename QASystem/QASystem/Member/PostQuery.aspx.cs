using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace QASystem.Member
{
    public partial class PostQuery : System.Web.UI.Page
    {

        DataTable tab = new DataTable();
        TableCell[] c;
        int z = 0;
        DataTable tab1 = new DataTable();
        DataTable tab2 = new DataTable();
        Dictionary<string, double> DictionaryAllFrequentItems = new Dictionary<string, double>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)

                TextBox1.Focus();

            if (Request.QueryString["text"] == null)
            {

            }
            else
            {
                TextBox1.Text = Request.QueryString["text"].ToString();

                btnSubmit_Click(sender, e);
                btnSubmit.Visible = false;
                TextBox1.Visible = false;
               
                System.Reflection.PropertyInfo isreadonly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                // make collection editable
                isreadonly.SetValue(this.Request.QueryString, false, null);
                // remove
                this.Request.QueryString.Remove("text");

               
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {           
            //code to identify the type of the query

            //code to remove the stop words [preprocessing of data]
            string[] stopwords = { "the", "is", "many", "are", "of", "in", "once", "after", "why", "take", "takes", "this", "during", "which", "what", "from", "both", "any", "how", "about", "a", "of", "that", "and", "worth", "held", "where", "best", "when", "to", "go" };

            string[] query = null;

            query = TextBox1.Text.Split(' ');

            for (int y = 0; y < query.Length; y++)
            {
                query[y] = query[y].Replace(",", String.Empty);
                //query[y] = query[y].Replace(".", String.Empty);
                query[y] = query[y].Replace("?", String.Empty);
                query[y] = query[y].Replace(":", String.Empty);
                query[y] = query[y].Replace("(", String.Empty);
                query[y] = query[y].Replace(")", String.Empty);
            }

            List<string> specialWords = new List<string>();

            for (int i = 0; i < query.Length; i++)
            {
                if (!stopwords.Contains(query[i], StringComparer.InvariantCultureIgnoreCase))
                {
                    //retreiving the special words/keywords from the query
                    specialWords.Add(query[i]);
                }
            }

            //storing the special words into the string array
            string[] terms = specialWords.ToArray();

            ArrayList arrayCount = new ArrayList();
            ArrayList arrayTypeId = new ArrayList();
            ArrayList arrayTemp = new ArrayList();

            BLL obj = new BLL();
            DataTable tabTypes = new DataTable();

            tabTypes = obj.GetTypes();

            for (int i = 0; i < tabTypes.Rows.Count; i++)
            {
                DataTable tabKeywords = new DataTable();
                tabKeywords = obj.GetKeywordsByType(int.Parse(tabTypes.Rows[i]["TypeId"].ToString()));

                int cnt = 0;

                for (int j = 0; j< tabKeywords.Rows.Count; j++)
                {                    
                    if (terms.Contains(tabKeywords.Rows[j]["Word"].ToString(), StringComparer.InvariantCultureIgnoreCase))
                    {
                        ++cnt;
                    }
                }

                //confidence level [number of keywords to match]
                if (cnt > 0)
                {
                    arrayCount.Add(cnt);
                    arrayTypeId.Add(tabTypes.Rows[i]["TypeId"].ToString());
                }               
            }

            if (arrayCount.Count > 0)
            {               
                for (int z = 0; z < arrayCount.Count; z++)
                {
                    arrayTemp.Add(arrayCount[z]);
                }

                arrayTemp.Sort();
                arrayTemp.Reverse();

                for (int h = 0; h < arrayTemp.Count; h++)
                {
                    if (arrayCount[h].Equals(arrayTemp[0]))
                    {
                        if (obj.CheckQuestion(TextBox1.Text))
                        {
                            //lblType.Font.Bold = true;
                            //lblType.ForeColor = System.Drawing.Color.Red;
                            //lblType.Text = "No Results Found for  the Query!!!";
                            if (Request.QueryString["text"] == null)
                            {
                                obj.InsertQuestion(int.Parse(Session["MemberId"].ToString()), int.Parse(arrayTypeId[h].ToString()), TextBox1.Text, DateTime.Now);
                            }           
                            
                        }

                        DataTable tabTypeName=new DataTable ();
                        tabTypeName=obj.GetTypeById(int.Parse(arrayTypeId[h].ToString()));

                        lblType.Font.Bold = true;
                        lblType.ForeColor = System.Drawing.Color.Black;
                        lblType.Text = "Query Type: " + tabTypeName.Rows[0]["QuestionType"].ToString() + " (Click on the Question to know the Answers) ";
                        
                        DataTable tabQuestions = new DataTable();

                        tabQuestions = obj.GetQuestionsByType(int.Parse(arrayTypeId[h].ToString()));

                        if (tabQuestions.Rows.Count > 0)
                        {
                            int serialNo = 1;

                            ArrayList arrayTemp1 = new ArrayList();
                            ArrayList arrayCount1 = new ArrayList();
                            ArrayList arrayQuestionId = new ArrayList();
                            ArrayList arrayExists = new ArrayList();
                            
                            for (int p = 0; p < tabQuestions.Rows.Count; p++)
                            {
                                //code to remove the stop words [preprocessing of data]
                                string[] stopwords1 = { "the", "is", "are", "this", "what", "how", "about", "a", "of", "that", "are", "where", "that", "when", "to" };

                                string[] query1 = null;

                                query1 = tabQuestions.Rows[p]["Question"].ToString().Split(' ');

                                for (int y = 0; y < query1.Length; y++)
                                {
                                    query1[y] = query1[y].Replace(",", String.Empty);
                                    //query[y] = query[y].Replace(".", String.Empty);
                                    query1[y] = query1[y].Replace("?", String.Empty);
                                    query1[y] = query1[y].Replace(":", String.Empty);
                                    query1[y] = query1[y].Replace("(", String.Empty);
                                    query1[y] = query1[y].Replace(")", String.Empty);
                                }


                                List<string> specialWords1 = new List<string>();

                                for (int i = 0; i < query1.Length; i++)
                                {
                                    if (!stopwords1.Contains(query1[i], StringComparer.InvariantCultureIgnoreCase))
                                    {
                                        //retreiving the special words/keywords from the query
                                        specialWords1.Add(query1[i]);
                                    }
                                }

                                //storing the special words into the string array
                                string[] terms1 = specialWords1.ToArray();

                                int cnt1 = 0;

                                for (int r = 0; r < terms1.Length; r++)
                                {
                                    if (terms.Contains(terms1[r], StringComparer.InvariantCultureIgnoreCase))
                                    {
                                        ++cnt1;
                                    }
                                }

                                //confidence level [number of keywords to match]
                                if (cnt1 > 0)
                                {
                                    arrayCount1.Add(cnt1);
                                    arrayQuestionId.Add(tabQuestions.Rows[p]["QuestionId"].ToString());
                                }
                            }

                            if (arrayCount1.Count > 0)
                            {
                                for (int z = 0; z < arrayCount1.Count; z++)
                                {
                                    arrayTemp1.Add(arrayCount1[z]);
                                }

                                arrayTemp1.Sort();
                                arrayTemp1.Reverse();

                                for (int v = 0; v < arrayCount1.Count; v++)
                                {
                                    int d = 0;

                                    for (int t = 0; t < arrayTemp1.Count; t++)
                                    {
                                        if (arrayCount1[t].Equals(arrayTemp1[v]))
                                        {
                                            if (d == 0 && !arrayExists.Contains(arrayQuestionId[t]))
                                            {
                                                arrayExists.Add(arrayQuestionId[t]);

                                                DataTable tabQues = new DataTable();
                                                tabQues = obj.GetQuestionById(int.Parse(arrayQuestionId[t].ToString()));

                                                TableRow row1 = new TableRow();

                                                TableCell row1_cell1 = new TableCell();
                                                row1_cell1.Font.Size = 10;
                                                row1_cell1.Text = serialNo + ".";
                                                row1.Controls.Add(row1_cell1);

                                                TableCell cell_topic = new TableCell();
                                                //cell_topic.Width = 750;
                                                HyperLink li = new HyperLink();
                                                li.ID = tabQues.Rows[0]["QuestionId"].ToString();
                                                li.Text = tabQues.Rows[0]["Question"].ToString();
                                                li.NavigateUrl = string.Format("Answers.aspx?Question={0}&QuestionId={1}", tabQues.Rows[0]["Question"].ToString(), tabQues.Rows[0]["QuestionId"].ToString());
                                                cell_topic.Controls.Add(li);
                                                row1.Controls.Add(cell_topic);

                                                TableRow row2 = new TableRow();

                                                TableCell row2Cell1 = new TableCell();
                                                row2Cell1.Text = " ";
                                                row2.Controls.Add(row2Cell1);

                                                TableCell row2Cell2 = new TableCell();
                                                row2Cell2.Text = "<br/>";
                                                row2.Controls.Add(row2Cell2);

                                                TableRow row3 = new TableRow();

                                                TableCell row3cell1 = new TableCell();
                                                row3cell1.Text = " ";
                                                row3.Controls.Add(row3cell1);

                                                DataTable tab50 = new DataTable();
                                                tab50.Rows.Clear();

                                                tab50 = obj.GetMemberById(int.Parse(tabQues.Rows[0]["MemberId"].ToString()));
                                                TableCell row3cell2 = new TableCell();
                                                row3cell2.Text = "Posted By : " + tab50.Rows[0]["FName"].ToString() + " ," + "Posted Date : " + tabQues.Rows[0]["PostedDate"].ToString() + "<br/>";
                                                row3.Controls.Add(row3cell2);

                                                TableRow row10 = new TableRow();

                                                TableCell row10_cell1 = new TableCell();
                                                row10_cell1.ColumnSpan = 10;
                                                row10_cell1.Width = 900;
                                                row10_cell1.Text = "<hr/>";
                                                row10.Controls.Add(row10_cell1);

                                                tableQA.Controls.Add(row1);
                                                tableQA.Controls.Add(row2);
                                                tableQA.Controls.Add(row3);
                                                tableQA.Controls.Add(row10);

                                                ++serialNo;

                                                break;

                                            }
                                        }

                                    }

                                }
                            }
                            else
                            {
                                tableQA.Rows.Clear();

                                TableHeaderRow row = new TableHeaderRow();
                                TableHeaderCell cell = new TableHeaderCell();
                                cell.HorizontalAlign = HorizontalAlign.Center;
                                cell.ForeColor = System.Drawing.Color.Red;
                                cell.Text = "No Results Found for the Query!!!";
                                row.Controls.Add(cell);

                                tableQA.Controls.Add(row);
                            }

                            Inputs(int.Parse(arrayTypeId[h].ToString()));
                        }
                        else
                        {
                            tableQA.Rows.Clear();

                            TableHeaderRow row = new TableHeaderRow();
                            TableHeaderCell cell = new TableHeaderCell();
                            cell.HorizontalAlign = HorizontalAlign.Center;
                            cell.ForeColor = System.Drawing.Color.Red;
                            cell.Text = "No Results Found for the Query!!!";
                            row.Controls.Add(cell);

                            tableQA.Controls.Add(row);
                        }

                    }
                }
                
               
                
            }
            else
            {
                tableQA.Rows.Clear();

                TableHeaderRow row = new TableHeaderRow();
                TableHeaderCell cell = new TableHeaderCell();
                cell.HorizontalAlign = HorizontalAlign.Center;
                cell.ForeColor = System.Drawing.Color.Red;
                cell.Text = "The Query can't be classified to any category!!!";
                row.Controls.Add(cell);

                tableQA.Controls.Add(row);

            }
            
        }

        #region -- Algorithm Steps ---

        //function to retrive the inputs for prediction
        private void Inputs(int typeId)
        {
            DataTable tabQuestions = new DataTable();
            BLL obj = new BLL();

            int totalCount = 30;
            DateTime currentDate;
            currentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            DateTime startDate;
            startDate = currentDate.AddDays(-totalCount);

            DateTime endDate;
            endDate = currentDate.AddDays(1);

            tabQuestions = obj.GetQuestionsByDateandMemberId(typeId, int.Parse(Session["MemberId"].ToString()), startDate, endDate);

            lv_Transactions.Items.Clear();
            lv_Items.Items.Clear();

            if (tabQuestions.Rows.Count > 0)
            {
                for (int p = 0; p < tabQuestions.Rows.Count; p++)
                {
                    //code to remove the stop words [preprocessing of data]
                    string[] stopwords1 = { "the", "is", "are", "this", "what", "does", "how", "about", "of", "that", "are", "where", "that", "when", "to", "and" };

                    string[] query1 = null;

                    query1 = tabQuestions.Rows[p]["Question"].ToString().Split(' ');

                    for (int y = 0; y < query1.Length; y++)
                    {
                        query1[y] = query1[y].Replace(",", String.Empty);
                        query1[y] = query1[y].Replace(" ", String.Empty);
                        query1[y] = query1[y].Replace("?", String.Empty);
                        query1[y] = query1[y].Replace(":", String.Empty);
                        query1[y] = query1[y].Replace("(", String.Empty);
                        query1[y] = query1[y].Replace(")", String.Empty);
                    }

                    List<string> specialWords1 = new List<string>();

                    for (int i = 0; i < query1.Length; i++)
                    {
                        if (!stopwords1.Contains(query1[i], StringComparer.InvariantCultureIgnoreCase))
                        {
                            //retreiving the special words/keywords from the query
                            specialWords1.Add(query1[i]);
                        }
                    }

                    //storing the special words into the string array
                    string[] terms1 = specialWords1.ToArray();
                    
                    DataTable tabKeywords = new DataTable();
                    tabKeywords = obj.GetKeywordsByType(typeId);

                    string record = null;

                    for (int j = 0; j < tabKeywords.Rows.Count; j++)
                    {
                        if (terms1.Contains(tabKeywords.Rows[j]["Word"].ToString(), StringComparer.InvariantCultureIgnoreCase))
                        {
                            record += tabKeywords.Rows[j]["Word"].ToString() + ",";
                        }
                    }
                                                           
                    lv_Transactions.Items.Add(record.Substring(0, record.Length - 1));
                }
            }
            else
            {
                tabQuestions = obj.GetQuestionsByDate(typeId, startDate, endDate);

                if (tabQuestions.Rows.Count > 0)
                {
                    for (int p = 0; p < tabQuestions.Rows.Count; p++)
                    {
                        //code to remove the stop words [preprocessing of data]
                        string[] stopwords1 = { "the", "is", "are", "this", "what", "how", "about", "of", "that", "are", "what", "how", "when", "to", "and" };

                        string[] query1 = null;

                        query1 = tabQuestions.Rows[p]["Question"].ToString().Split(' ');

                        for (int y = 0; y < query1.Length; y++)
                        {
                            query1[y] = query1[y].Replace(",", String.Empty);
                            query1[y] = query1[y].Replace(" ", String.Empty);
                            query1[y] = query1[y].Replace("?", String.Empty);
                            query1[y] = query1[y].Replace(":", String.Empty);
                            query1[y] = query1[y].Replace("(", String.Empty);
                            query1[y] = query1[y].Replace(")", String.Empty);
                        }

                        List<string> specialWords1 = new List<string>();

                        for (int i = 0; i < query1.Length; i++)
                        {
                            if (!stopwords1.Contains(query1[i], StringComparer.InvariantCultureIgnoreCase))
                            {
                                //retreiving the special words/keywords from the query
                                specialWords1.Add(query1[i]);
                            }
                        }

                        //storing the special words into the string array
                        string[] terms1 = specialWords1.ToArray();

                        DataTable tabKeywords = new DataTable();
                        tabKeywords = obj.GetKeywordsByType(typeId);

                        string record = null;

                        for (int j = 0; j < tabKeywords.Rows.Count; j++)
                        {
                            if (terms1.Contains(tabKeywords.Rows[j]["Word"].ToString(), StringComparer.InvariantCultureIgnoreCase))
                            {
                                record += tabKeywords.Rows[j]["Word"].ToString() + ",";
                            }
                        }

                        lv_Transactions.Items.Add(record.Substring(0, record.Length - 1));
                    }
                }
                else
                {
                    tableQA.Rows.Clear();

                    TableHeaderRow row = new TableHeaderRow();
                    TableHeaderCell cell = new TableHeaderCell();

                    cell.ForeColor = System.Drawing.Color.Red;
                    cell.Text = "No Questions Found for Mining";

                    row.Controls.Add(cell);

                    tableQA.Controls.Add(row);
                }
            }

            if (lv_Transactions.Items.Count > 0)
            {
                for (int i = 0; i < lv_Transactions.Items.Count; i++)
                {
                    string[] items = null;
                    items = lv_Transactions.Items[i].Text.Split(',');

                    for (int w = 0; w < items.Length; w++)
                    {
                        ListItem item = new ListItem();
                        item.Text = items[w];

                        if (lv_Items.Items.Contains(item))
                        {

                        }
                        else
                        {
                            lv_Items.Items.Add(items[w]);
                        }
                    }
                }

                Solve();
            }
        }

        private void Solve()
        {
            double MinSupport = 0.07;
            double MinConfidence = 0.4;
            ////Scan the transaction database to get the support S of each 1-itemset,
            Dictionary<string, double> DictionaryFrequentItemsList1 = GetList1FrequentItems(MinSupport);
            Dictionary<string, double> DictionaryFrequentItemsMain = DictionaryFrequentItemsList1;
            Dictionary<string, double> DictionaryCandidates = new Dictionary<string, double>();
            do
            {
                DictionaryCandidates = GenerateCandidates(DictionaryFrequentItemsMain);
                DictionaryFrequentItemsMain = GetFrequentItems(DictionaryCandidates, MinSupport);
            }
            while (DictionaryCandidates.Count != 0);
            //MessageBox.Show("Hello");
            List<ClassRules> RulesList = GenerateRules();
            List<ClassRules> StrongRules = GetStrongRules(MinConfidence, RulesList);
            Result(DictionaryAllFrequentItems, StrongRules);
            //SolutionObject.ShowDialog();
        }

        //FUNCTION TO GET THE FIRST LIST OF FREQUENT ITEMS OCCURING IN THE SET OF TRANSACTIONS
        private Dictionary<string, double> GetList1FrequentItems(double MinSupport)
        {
            Dictionary<string, double> DictionaryFrequentItemsReturn = new Dictionary<string, double>();
            for (int i = 0; i < lv_Items.Items.Count; i++)
            {
                double Support = GetSupport(lv_Items.Items[i].Text.ToString());
                if ((Support / (double)(lv_Transactions.Items.Count) >= MinSupport))
                {
                    DictionaryFrequentItemsReturn.Add(lv_Items.Items[i].Text.ToString(), Support);

                    DictionaryAllFrequentItems.Add(lv_Items.Items[i].Text.ToString(), Support);
                }
            }
            return DictionaryFrequentItemsReturn;
        }

        //FUNCTION GETS THE SUPPORT FOR EACH INDIVIDUAL ITEMS IN SET OF TRANSACTIONS
        private double GetSupport(string GeneratedCandidate)
        {
            double SupportReturn = 0;

            string[] AllTransactions = new string[lv_Transactions.Items.Count];
            for (int i = 0; i < lv_Transactions.Items.Count; i++)
            {
                AllTransactions[i] = lv_Transactions.Items[i].Text.ToString();
            }
            foreach (string Transaction in AllTransactions)
            {
                if (IsSubstring(GeneratedCandidate, Transaction))
                {
                    SupportReturn++;
                }
            }

            return SupportReturn;
        }

        //FUNCTION TO CHECK IF THE ITEM EXISTS IN A GIVEN TRANSACTION
        private bool IsSubstring(string Child, string Parent)
        {
            string[] TransactionArray = Child.Split(',');
            //string value = null;
            foreach (string Item in TransactionArray)
            {
                if (!Parent.Contains(Item))
                    return false;
            }
            return true;
        }

        //FUNCTION TO GENERATE CANDIDATES FROM THE FREQUENT ITEM LIST
        //GET THE FIRST ITEM - ADD THE NEXT ITEM - SORT ITEMS
        //GET THE CANDIDATES EXCLUDING THE SIMILAR ITEMS
        //GET SUPPORT AND ADD TO DICTIONARY

        private Dictionary<string, double> GenerateCandidates(Dictionary<string, double> MainFrequentItems)
        {
            Dictionary<string, double> DictionaryCandidatesReturn = new Dictionary<string, double>();
            for (int i = 0; i < MainFrequentItems.Count - 1; i++)
            {
                string[] FirstItem = Alphabetize(MainFrequentItems.Keys.ElementAt(i));
                string FirstItemString = null;
                for (int k = 0; k < FirstItem.Length; k++)
                {
                    FirstItemString += FirstItem[k].ToString() + ",";
                }
                FirstItemString = FirstItemString.Remove(FirstItemString.Length - 1);
                for (int j = i + 1; j < MainFrequentItems.Count; j++)
                {
                    string[] SecondItem = Alphabetize(MainFrequentItems.Keys.ElementAt(j));
                    string SecondItemString = null;
                    for (int l = 0; l < SecondItem.Length; l++)
                    {
                        SecondItemString += SecondItem[l].ToString() + ",";
                    }
                    SecondItemString = SecondItemString.Remove(SecondItemString.Length - 1);
                    string GeneratedCandidate = GetCandidate(FirstItemString, SecondItemString);
                    //MessageBox.Show("A " + GeneratedCandidate);
                    //string GeneratedCandidate = GetCandidate("Brush,Lace,Socks,Shoe", "Brush,Lace,Socks,Polish");
                    if (GeneratedCandidate != string.Empty)
                    {
                        string[] CandidateArray = Alphabetize(GeneratedCandidate);
                        GeneratedCandidate = "";
                        for (int m = 0; m < CandidateArray.Length; m++)
                        {
                            GeneratedCandidate += CandidateArray[m].ToString() + ",";
                        }

                        GeneratedCandidate = GeneratedCandidate.Remove(GeneratedCandidate.Length - 1);
                        double Support = GetSupport(GeneratedCandidate);
                        DictionaryCandidatesReturn.Add(GeneratedCandidate, Support);
                    }
                }
            }
            return DictionaryCandidatesReturn;
        }

        //FUNCTION TO SORT THE GIVEN ITEMS IN ALPHABETICAL ORDER
        private string[] Alphabetize(string Token)
        {
            // Convert to char array, then sort and return
            string[] TokenArray = Token.Split(',');
            Array.Sort(TokenArray);
            return TokenArray;
        }

        //FUNCTION TO GET CANDIDATE EXCLUDING THE SIMILAR ITEMS.
        private string GetCandidate(string FirstItemString, string SecondItemString)
        {
            string CandidateJoin = null;
            if (FirstItemString.Contains(',') || SecondItemString.Contains(','))
            {
                string[] First = FirstItemString.Split(',');
                string[] Second = SecondItemString.Split(',');
                if (First[0] != Second[0])
                {
                    return string.Empty;
                }
                else
                {
                    string firstString = FirstItemString.Substring(0, FirstItemString.LastIndexOf(','));
                    string secondString = SecondItemString.Substring(0, SecondItemString.LastIndexOf(','));
                    if (firstString == secondString)
                    {
                        return FirstItemString + SecondItemString.Substring(SecondItemString.LastIndexOf(','));
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                ////int i=0;
                ////int x = 0;
                ////for ( i = 0; i < First.Length; i++)
                ////{
                ////    if (Second.Length > i)
                ////    {
                ////        if (First[i] == Second[i])
                ////        {
                ////            CandidateJoin = CandidateJoin + "," + First[i];
                ////            x = i;
                ////        }
                ////    }
                ////}

                ////for (i=x+1; i < First.Length; i++)
                ////{
                ////    CandidateJoin = CandidateJoin + "," + First[i];
                ////}
                ////for (x=x+1; x < Second.Length; x++)
                ////{
                ////    CandidateJoin = CandidateJoin + "," + Second[x];
                ////}
                ////return CandidateJoin.Substring(1);


                //string FirstSubString = FirstItemString.Substring(0, FirstItemString.IndexOf(','));
                //string SecondSubString = SecondItemString.Substring(0, SecondItemString.IndexOf(','));
                //if (FirstSubString == SecondSubString)
                //{
                //    return FirstItemString + SecondItemString.Substring(SecondItemString.IndexOf(','));
                //}
                //else
                //    return string.Empty;
            }
            else
            {
                return FirstItemString + "," + SecondItemString;
            }
        }

        //FUNCTION TO GET FREQUENT ITEMS THROUGH GIVEN SUPPORT
        private Dictionary<string, double> GetFrequentItems(Dictionary<string, double> CandidatesDictionary, double MinimumSupport)
        {
            Dictionary<string, double> FrequentReturn = new Dictionary<string, double>();
            for (int i = CandidatesDictionary.Count - 1; i >= 0; i--)
            {
                string Item = CandidatesDictionary.Keys.ElementAt(i);
                double Support = CandidatesDictionary[Item];
                if ((Support / (double)(lv_Transactions.Items.Count) >= MinimumSupport))
                {
                    FrequentReturn.Add(Item, Support);
                    DictionaryAllFrequentItems.Add(Item, Support);
                }
            }
            return FrequentReturn;
        }

        //FUNCTION TO GENERATE RULES
        private List<ClassRules> GenerateRules()
        {
            List<ClassRules> RulesReturnList = new List<ClassRules>();
            foreach (string Item in DictionaryAllFrequentItems.Keys)
            {
                string[] ItemArray = Item.Split(',');
                if (ItemArray.Length > 1)
                {
                    int MaxCombinationLength = ItemArray.Length / 2;
                    GenerateCombination(Item, MaxCombinationLength, ref RulesReturnList);
                }
            }
            return RulesReturnList;
        }

        private void GenerateCombination(string Item, int CombinationLength, ref List<ClassRules> RulesReturnList)
        {
            string[] ItemArray = Item.Split(',');
            int ItemLength = ItemArray.Length;
            if (ItemLength == 2)
            {
                AddItem(ItemArray[0].ToString(), Item, ref RulesReturnList);
                return;
            }
            else if (ItemLength == 3)
            {
                for (int i = 0; i < ItemLength; i++)
                {
                    AddItem(ItemArray[i].ToString(), Item, ref RulesReturnList);
                }
                return;
            }
            else
            {
                for (int i = 0; i < ItemLength; i++)
                {
                    GetCombinationRecursive(ItemArray[i].ToString(), Item, CombinationLength, ref RulesReturnList);
                }
            }
        }

        private void AddItem(string Combination, string Item, ref List<ClassRules> RulesReturnList)
        {
            string Remaining = GetRemaining(Combination, Item);
            ClassRules Rule = new ClassRules(Combination, Remaining, 0);
            RulesReturnList.Add(Rule);
        }

        private string GetCombinationRecursive(string Combination, string Item, int CombinationLength, ref List<ClassRules> RulesReturnList)
        {
            AddItem(Combination, Item, ref RulesReturnList);
            string LastTokenItem = Combination;
            if (Combination.Contains(','))
                LastTokenItem = Combination.Substring(Combination.LastIndexOf(',') + 1);

            string NextItem = null; ;
            string LastItem = Item.Substring(Item.LastIndexOf(',') + 1);
            if (Combination.Split(',').Length == CombinationLength)
            {
                if (LastTokenItem != LastItem)
                {
                    string TempCombination = null;
                    foreach (string str in Combination.Split(','))
                    {
                        if (str != LastTokenItem)
                        {
                            TempCombination = TempCombination + "," + str;
                        }
                    }
                    Combination = TempCombination.Substring(1);
                    string[] strs = Item.Split(',');
                    for (int i = 0; i < strs.Length; i++)
                    {
                        if (strs[i] == LastTokenItem)
                        {
                            NextItem = strs[i + 1];
                        }
                    }
                    //Combination = Combination.Remove(nLastTokenCharcaterIndex, 1);
                    //NextItem = Item[nLastTokenCharcaterIndexInParent + 1];
                    string strNewToken = Combination + "," + NextItem;
                    return (GetCombinationRecursive(strNewToken, Item, CombinationLength, ref RulesReturnList));
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                if (Combination != LastItem.ToString())
                {
                    string[] strs = Item.Split(',');
                    for (int i = 0; i < strs.Length; i++)
                    {
                        if (strs[i] == LastTokenItem)
                        {
                            NextItem = strs[i + 1];
                        }
                    }
                    //NextItem = Item[nLastTokenCharcaterIndexInParent + 1];
                    string strNewToken = Combination + "," + NextItem;
                    return (GetCombinationRecursive(strNewToken, Item, CombinationLength, ref RulesReturnList));
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        private string GetRemaining(string Child, string Parent)
        {
            string[] childArray = Child.Split(',');
            for (int i = 0; i < childArray.Length; i++)
            {
                string Remaining = null;
                string[] ParentArray = Parent.Split(',');
                for (int j = 0; j < ParentArray.Length; j++)
                {
                    if (childArray[i] != ParentArray[j])
                    {
                        Remaining = Remaining + "," + ParentArray[j];
                    }
                }
                if (Remaining.Contains(','))
                    Parent = Remaining.Substring(1);
                else
                    Parent = Remaining;
            }
            return Parent;
        }

        private List<ClassRules> GetStrongRules(double MinConfidence, List<ClassRules> RulesList)
        {
            List<ClassRules> StrongRulesReturn = new List<ClassRules>();
            foreach (ClassRules Rule in RulesList)
            {
                string[] XY = Alphabetize(Rule.X + "," + Rule.Y);
                string XYString = null;
                for (int i = 0; i < XY.Length; i++)
                {
                    XYString += XY[i] + ",";
                }
                XYString = XYString.Remove(XYString.Length - 1);
                AddStrongRule(Rule, XYString, ref StrongRulesReturn, MinConfidence);
            }
            StrongRulesReturn.Sort();
            return StrongRulesReturn;
        }

        private void AddStrongRule(ClassRules Rule, string XY, ref List<ClassRules> StrongRulesReturn, double MinConfidence)
        {
            double Confidence = GetConfidence(Rule.X, XY);
            ClassRules NewRule;
            if (Confidence >= MinConfidence)
            {
                NewRule = new ClassRules(Rule.X, Rule.Y, Confidence);
                StrongRulesReturn.Add(NewRule);
            }
            Confidence = GetConfidence(Rule.Y, XY);
            if (Confidence >= MinConfidence)
            {
                NewRule = new ClassRules(Rule.Y, Rule.X, Confidence);
                StrongRulesReturn.Add(NewRule);
            }
        }

        private double GetConfidence(string X, string XY)
        {
            double Support_X, Support_XY;
            Support_X = DictionaryAllFrequentItems[X];
            Support_XY = DictionaryAllFrequentItems[XY];
            return Support_XY / Support_X;
        }

        public void Result(Dictionary<string, double> AllFrequentItems, List<ClassRules> StrongRulesList)
        {
            LoadFrequentItems(AllFrequentItems);
            LoadRules(StrongRulesList);
        }

        private void LoadFrequentItems(Dictionary<string, double> AllFrequentItems)
        {

            foreach (string Item in AllFrequentItems.Keys)
            {
                ListItem items = new ListItem(Item);
                ListBox1.Items.Add(items);
            }
        }

        private void LoadRules(List<ClassRules> StrongRulesList)
        {
            tblRecc.Rows.Clear();
            tblRecc.GridLines = GridLines.Both;

            TableHeaderRow mainrow1 = new TableHeaderRow();
            //mainrow1.ForeColor = System.Drawing.Color.Black;
            mainrow1.BackColor = System.Drawing.Color.AliceBlue;

            TableHeaderCell cell1 = new TableHeaderCell();
            cell1.Width = 550;
            cell1.HorizontalAlign = HorizontalAlign.Center;
            cell1.Font.Size = 22;
            cell1.ForeColor = System.Drawing.Color.Green;
            cell1.Text = "Prediction";
            mainrow1.Controls.Add(cell1);

                      
            tblRecc.Controls.Add(mainrow1);

            int i = 0;

            if (StrongRulesList.Count > 0)
            {
                //Session["patterns"] = StrongRulesList;
                ListBox2.Items.Clear();

                foreach (ClassRules Rule in StrongRulesList)
                {
                    ListItem items = new ListItem(Rule.X + ">" + Rule.Y);
                    ListBox2.Items.Add(items);

                    TableRow row = new TableRow();

                    TableCell cell_rule1 = new TableCell();
                    cell_rule1.ForeColor = System.Drawing.Color.Green;

                    HyperLink link1 = new HyperLink();
                    link1.Text = Rule.X;
                    link1.ID = "Link1~" + Rule.X + "~" + i;

                    string[] qry;
                    string actual = null;

                    if (link1.Text.Contains(','))
                    {
                        qry = link1.Text.Split(',');

                        for (int r = 0; r < qry.Length; r++)
                        {
                            actual += qry[r] + " ";
                        }

                        link1.NavigateUrl = string.Format("PostQuery.aspx?text={0}", actual.Substring(0, actual.Length - 1));

                    }
                    else
                    {
                        link1.NavigateUrl = string.Format("PostQuery.aspx?text={0}", link1.Text);
                    }

                    ++i;

                    Label lblSpace = new Label();
                    lblSpace.Text = "-->";

                    
                   
                    HyperLink link2 = new HyperLink();
                    link2.Text = Rule.Y;
                    link2.ID = "Link2~" + Rule.Y + "~" + i;

                    string[] qry1;
                    string actual1 = null;

                    if (link2.Text.Contains(','))
                    {
                        qry1 = link2.Text.Split(',');

                        for (int r = 0; r < qry1.Length; r++)
                        {
                            actual1 += qry1[r] + " ";
                        }

                        link2.NavigateUrl = string.Format("PostQuery.aspx?text={0}", actual1.Substring(0, actual1.Length - 1));

                    }
                    else
                    {

                        link2.NavigateUrl = string.Format("PostQuery.aspx?text={0}", link2.Text);

                    }


                    ++i;
                   // cell_rule3.Controls.Add(link2);
                    //row.Controls.Add(cell_rule3);

                   
                    cell_rule1.Controls.AddAt(0, link1);
                    cell_rule1.Controls.AddAt(1, lblSpace);
                    cell_rule1.Controls.AddAt(2, link2);
                    row.Controls.Add(cell_rule1);


                    tblRecc.Controls.Add(row);

                    ++i;
                }                
            }

            else
            {
                tblRecc.Rows.Clear();
                tblRecc.GridLines = GridLines.None;

                TableHeaderRow row = new TableHeaderRow();
                TableHeaderCell cell = new TableHeaderCell();
                cell.HorizontalAlign = HorizontalAlign.Center;
                cell.Font.Bold = true;
                cell.ForeColor = System.Drawing.Color.Red;
                cell.ColumnSpan = 5;
                cell.Text = "No Patterns Found for the Input!!!";
                row.Controls.Add(cell);

                tblRecc.Controls.Add(row);
            }
        }
               
        #endregion


        //protected void btnNext_Click(object sender, EventArgs e)
        //{
        //    //code to remove the stop words [preprocessing of data]
        //    string[] stopwords = { "the", "is", "are", "this", "what", "how", "about", "of", "that", "are", "what", "how", "when", "to", "and" };

        //    string[] query = null;

        //    query = TextBox1.Text.Split(' ');

        //    for (int y = 0; y < query.Length; y++)
        //    {
        //        query[y] = query[y].Replace(",", String.Empty);
        //        query[y] = query[y].Replace(" ", String.Empty);
        //        query[y] = query[y].Replace("?", String.Empty);
        //        query[y] = query[y].Replace(":", String.Empty);
        //        query[y] = query[y].Replace("(", String.Empty);
        //        query[y] = query[y].Replace(")", String.Empty);
        //    }

        //    List<string> specialWords = new List<string>();

        //    for (int i = 0; i < query.Length; i++)
        //    {
        //        // if (!stopwords.Contains(title[i], StringComparer.InvariantCultureIgnoreCase))
        //        if (!stopwords.Contains(query[i], StringComparer.InvariantCultureIgnoreCase))
        //        {
        //            //retreiving the special words/keywords from the query
        //            specialWords.Add(query[i]);
        //        }
        //    }

        //    //storing the special words into the string array
        //    string[] terms = specialWords.ToArray();

        //    ArrayList arrayCount = new ArrayList();
        //    ArrayList arrayTypeId = new ArrayList();
        //    ArrayList arrayTemp = new ArrayList();

        //    string queryKeywords = null;

        //    if (terms.Length > 0)
        //    {
        //        BLL obj = new BLL();
        //        DataTable tabTypes = new DataTable();

        //        tabTypes = obj.GetTypes();

        //        for (int i = 0; i < tabTypes.Rows.Count; i++)
        //        {
        //            DataTable tabKeywords = new DataTable();
        //            tabKeywords = obj.GetKeywordsByType(int.Parse(tabTypes.Rows[i]["TypeId"].ToString()));

        //            int cnt = 0;

        //            for (int j = 0; j < tabKeywords.Rows.Count; j++)
        //            {
        //                if (terms.Contains(tabKeywords.Rows[j]["Word"].ToString(), StringComparer.InvariantCultureIgnoreCase))
        //                {
        //                    ++cnt;
        //                }
        //            }

        //            //confidence level [number of keywords to match]
        //            if (cnt > 0)
        //            {
        //                arrayCount.Add(cnt);
        //                arrayTypeId.Add(tabTypes.Rows[i]["TypeId"].ToString());
        //            }
        //        }

        //        if (arrayCount.Count > 0)
        //        {
        //            for (int z = 0; z < arrayCount.Count; z++)
        //            {
        //                arrayTemp.Add(arrayCount[z]);
        //            }

        //            arrayTemp.Sort();
        //            arrayTemp.Reverse();

        //            for (int h = 0; h < arrayTemp.Count; h++)
        //            {
        //                if (arrayCount[h].Equals(arrayTemp[0]))
        //                {
        //                    for (int i = 0; i < terms.Length; i++)
        //                    {
        //                        queryKeywords += terms[i] + ",";
        //                    }
        //                    //arrayTypeId[h].ToString())
        //                    Response.Redirect(string.Format("NextQuestion.aspx?keywords={0}&typeId={1}", queryKeywords.Substring(0, queryKeywords.Length - 1), arrayTypeId[h].ToString()));
        //                }
        //            }
        //        }
        //        else
        //        {
        //            ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('No Keywords Found in the Query')</script>");
        //        }
        //    }
        //    else
        //    {
        //        ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('No Keywords Found in the Query')</script>");
        //    }

        //}
    }
}