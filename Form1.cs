using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
	public partial class SudokuSolver : Form {
		public SudokuSolver() {
			InitializeComponent();
            label1.Text = null;
		}

		private void btnSolve_Click(object sender, EventArgs e) {
			int masterAttempts = 0;
			do {
				int attempts = 0;
				//When the user hits "solve", a Dictionary is created of all the current values. 
				//This links each cell with its 3D location (row, column, quadrant)
				//This step does not need to be repeated - values in dictionary should be updated automatically

				#region Create Dictionary
				Dictionary<string, TextBox> puzzleTable = new Dictionary<string, TextBox>();
				//Q1
				puzzleTable.Add("000", tb1);
				puzzleTable.Add("010", tb2);
				puzzleTable.Add("020", tb3);
				puzzleTable.Add("100", tb4);
				puzzleTable.Add("110", tb5);
				puzzleTable.Add("120", tb6);
				puzzleTable.Add("200", tb7);
				puzzleTable.Add("210", tb8);
				puzzleTable.Add("220", tb9);
				//Q2
				puzzleTable.Add("031", tb10);
				puzzleTable.Add("041", tb11);
				puzzleTable.Add("051", tb12);
				puzzleTable.Add("131", tb13);
				puzzleTable.Add("141", tb14);
				puzzleTable.Add("151", tb15);
				puzzleTable.Add("231", tb16);
				puzzleTable.Add("241", tb17);
				puzzleTable.Add("251", tb18);
				//Q3
				puzzleTable.Add("062", tb19);
				puzzleTable.Add("072", tb20);
				puzzleTable.Add("082", tb21);
				puzzleTable.Add("162", tb22);
				puzzleTable.Add("172", tb23);
				puzzleTable.Add("182", tb24);
				puzzleTable.Add("262", tb25);
				puzzleTable.Add("272", tb26);
				puzzleTable.Add("282", tb27);
				//Q4
				puzzleTable.Add("303", tb28);
				puzzleTable.Add("313", tb29);
				puzzleTable.Add("323", tb30);
				puzzleTable.Add("403", tb31);
				puzzleTable.Add("413", tb32);
				puzzleTable.Add("423", tb33);
				puzzleTable.Add("503", tb34);
				puzzleTable.Add("513", tb35);
				puzzleTable.Add("523", tb36);
				//Q5
				puzzleTable.Add("334", tb37);
				puzzleTable.Add("344", tb38);
				puzzleTable.Add("354", tb39);
				puzzleTable.Add("434", tb40);
				puzzleTable.Add("444", tb41);
				puzzleTable.Add("454", tb42);
				puzzleTable.Add("534", tb43);
				puzzleTable.Add("544", tb44);
				puzzleTable.Add("554", tb45);
				//Q6
				puzzleTable.Add("365", tb46);
				puzzleTable.Add("375", tb47);
				puzzleTable.Add("385", tb48);
				puzzleTable.Add("465", tb49);
				puzzleTable.Add("475", tb50);
				puzzleTable.Add("485", tb51);
				puzzleTable.Add("565", tb52);
				puzzleTable.Add("575", tb53);
				puzzleTable.Add("585", tb54);
				//Q7
				puzzleTable.Add("606", tb55);
				puzzleTable.Add("616", tb56);
				puzzleTable.Add("626", tb57);
				puzzleTable.Add("706", tb58);
				puzzleTable.Add("716", tb59);
				puzzleTable.Add("726", tb60);
				puzzleTable.Add("806", tb61);
				puzzleTable.Add("816", tb62);
				puzzleTable.Add("826", tb63);
				//Q8
				puzzleTable.Add("637", tb64);
				puzzleTable.Add("647", tb65);
				puzzleTable.Add("657", tb66);
				puzzleTable.Add("737", tb67);
				puzzleTable.Add("747", tb68);
				puzzleTable.Add("757", tb69);
				puzzleTable.Add("837", tb70);
				puzzleTable.Add("847", tb71);
				puzzleTable.Add("857", tb72);
				//Q9
				puzzleTable.Add("668", tb73);
				puzzleTable.Add("678", tb74);
				puzzleTable.Add("688", tb75);
				puzzleTable.Add("768", tb76);
				puzzleTable.Add("778", tb77);
				puzzleTable.Add("788", tb78);
				puzzleTable.Add("868", tb79);
				puzzleTable.Add("878", tb80);
				puzzleTable.Add("888", tb81);


				#endregion

				//After all values and nulls are stored, the values contained in every row,
				//column, and quadrant are stored individually. 

				#region Array Variables
				//Variables
				string[] arraynum = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
				TextBox[] row1 = { tb1, tb2, tb3, tb10, tb11, tb12, tb19, tb20, tb21 };
				TextBox[] row2 = { tb4, tb5, tb6, tb13, tb14, tb15, tb22, tb23, tb24 };
				TextBox[] row3 = { tb7, tb8, tb9, tb16, tb17, tb18, tb25, tb26, tb27 };
				TextBox[] row4 = { tb28, tb29, tb30, tb37, tb38, tb39, tb46, tb47, tb48 };
				TextBox[] row5 = { tb31, tb32, tb33, tb40, tb41, tb42, tb49, tb50, tb51 };
				TextBox[] row6 = { tb34, tb35, tb36, tb43, tb44, tb45, tb52, tb53, tb54 };
				TextBox[] row7 = { tb55, tb56, tb57, tb64, tb65, tb66, tb73, tb74, tb75 };
				TextBox[] row8 = { tb58, tb59, tb60, tb67, tb68, tb69, tb76, tb77, tb78 };
				TextBox[] row9 = { tb61, tb62, tb63, tb70, tb71, tb72, tb79, tb80, tb81 };
				TextBox[] col1 = { tb1, tb4, tb7, tb28, tb31, tb34, tb55, tb58, tb61 };
				TextBox[] col2 = { tb2, tb5, tb8, tb29, tb32, tb35, tb56, tb59, tb62 };
				TextBox[] col3 = { tb3, tb6, tb9, tb30, tb33, tb36, tb57, tb60, tb63 };
				TextBox[] col4 = { tb10, tb13, tb16, tb37, tb40, tb43, tb64, tb67, tb70 };
				TextBox[] col5 = { tb11, tb14, tb17, tb38, tb41, tb44, tb65, tb68, tb71 };
				TextBox[] col6 = { tb12, tb15, tb18, tb39, tb42, tb45, tb66, tb69, tb72 };
				TextBox[] col7 = { tb19, tb22, tb25, tb46, tb49, tb52, tb73, tb76, tb79 };
				TextBox[] col8 = { tb20, tb23, tb26, tb47, tb50, tb53, tb74, tb77, tb80 };
				TextBox[] col9 = { tb21, tb24, tb27, tb48, tb51, tb54, tb75, tb78, tb81 };
				TextBox[] q1 = { tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9 };
				TextBox[] q2 = { tb10, tb11, tb12, tb13, tb14, tb15, tb16, tb17, tb18 };
				TextBox[] q3 = { tb19, tb20, tb21, tb22, tb23, tb24, tb25, tb26, tb27 };
				TextBox[] q4 = { tb28, tb29, tb30, tb31, tb32, tb33, tb34, tb35, tb36 };
				TextBox[] q5 = { tb37, tb38, tb39, tb40, tb41, tb42, tb43, tb44, tb45 };
				TextBox[] q6 = { tb46, tb47, tb48, tb49, tb50, tb51, tb52, tb53, tb54 };
				TextBox[] q7 = { tb55, tb56, tb57, tb58, tb59, tb60, tb61, tb62, tb63 };
				TextBox[] q8 = { tb64, tb65, tb66, tb67, tb68, tb69, tb70, tb71, tb72 };
				TextBox[] q9 = { tb73, tb74, tb75, tb76, tb77, tb78, tb79, tb80, tb81 };
				List<TextBox> allCells = new List<TextBox>
			{
				tb1,
				tb2,
				tb3,
				tb4,
				tb5,
				tb6,
				tb7,
				tb8,
				tb9,
				tb10,
				tb11,
				tb12,
				tb13,
				tb14,
				tb15,
				tb16,
				tb17,
				tb18,
				tb19,
				tb20,
				tb21,
				tb22,
				tb23,
				tb24,
				tb25,
				tb26,
				tb27,
				tb28,
				tb29,
				tb30,
				tb31,
				tb32,
				tb33,
				tb34,
				tb35,
				tb36,
				tb37,
				tb38,
				tb39,
				tb40,
				tb41,
				tb42,
				tb43,
				tb44,
				tb45,
				tb46,
				tb47,
				tb48,
				tb49,
				tb50,
				tb51,
				tb52,
				tb53,
				tb54,
				tb55,
				tb56,
				tb57,
				tb58,
				tb59,
				tb60,
				tb61,
				tb62,
				tb63,
				tb64,
				tb65,
				tb66,
				tb67,
				tb68,
				tb69,
				tb70,
				tb71,
				tb72,
				tb73,
				tb74,
				tb75,
				tb76,
				tb77,
				tb78,
				tb79,
				tb80,
				tb81
			};
				List<TextBox[]> arrayRows = new List<TextBox[]>
			{
				row1,
				row2,
				row3,
				row4,
				row5,
				row6,
				row7,
				row8,
				row9
			};
				List<TextBox[]> arrayCols = new List<TextBox[]>
			{
				col1,
				col2,
				col3,
				col4,
				col5,
				col6,
				col7,
				col8,
				col9
			};
				List<TextBox[]> arrayQs = new List<TextBox[]>
			{
				q1,
				q2,
				q3,
				q4,
				q5,
				q6,
				q7,
				q8,
				q9
			};


				#endregion


				//These variables (rowPos, colPos, quaPos) track position in the grid and
				//allow for checking against the dictionary. 
				//"sPos" is the string version of those coordinates.
				int rowPos = 0;
				int colPos = 0;
				int quaPos = 0;
				string sPos;

				//complete and listcheckcomplete will be used to end the do loop.
				//bool complete = false;
				List<string> listcheckcomplete = new List<string>();

				IDictionary<string, List<string>> savedValues = new Dictionary<string, List<string>>();
				IDictionary<string, List<string>> updatedsavedValues = new Dictionary<string, List<string>>();
				List<int> listpositions = new List<int> { 0, 0, 0 };
				do {
					try {

						//Ensure table is not blank
						foreach (var cell in puzzleTable.Values.ToList()) {
							if (!string.IsNullOrEmpty(cell.Text)) {
								listcheckcomplete.Add(cell.Text);
							}
						}
						if (listcheckcomplete.Count == 0) {
							throw new SystemException("Please enter values");
						}


						foreach (var cell in puzzleTable.Values.ToList()) {
							sPos = rowPos.ToString() + colPos.ToString() + quaPos.ToString();
							//we only want cells that are empty
							if (string.IsNullOrEmpty(cell.Text)) {
								//Get a list of potential values based on the quadrant the current cell is in
								List<string> quadPotentialValues = findMissingValues(arrayQs[quaPos]);

								//iterate through that list in comparison to the rows and columns the cell belongs to
								foreach (var quadValue in quadPotentialValues.ToList()) {
									//these are EXISTING values in the rows. If it exists in the row, the current cell cannot contain it
									foreach (var rowValue in arrayRows[rowPos]) {
										if (rowValue.Text == quadValue) {
											//If they match, remove the value from the possibles list
											quadPotentialValues.Remove(quadValue);
										}
									}

									//Do the same for columns, making sure not to double check values that have already been removed
									if (quadPotentialValues.Contains(quadValue)) {
										foreach (var colValue in arrayCols[colPos]) {
											if (colValue.Text == quadValue) {
												quadPotentialValues.Remove(quadValue);
											}
										}
									}

									if (quadPotentialValues.Count == 1) {
										cell.Text = quadPotentialValues[0];
									} else if (!savedValues.Keys.Contains(sPos)) {
										savedValues.Add(sPos, quadPotentialValues);
									}
								}
							}

							//Counters update. This gives the exact position of each cell
							listpositions = updateCounters(rowPos, colPos, quaPos);
							rowPos = listpositions[0];
							colPos = listpositions[1];
							quaPos = listpositions[2];
						}
					} catch (Exception ex) {
						if (ex.ToString().Contains("Please enter values")) {
							label1.Text = "Error: Please enter values into the table";
						} else {
							label1.Text = "Error: " + ex;
						}
					}
					attempts++;
				} while (attempts != 5);


				try {
					List<string> potentialValuesList = new List<string>();
					int counter = 0;
					do {
						rowPos = 0;
						colPos = 0;
						quaPos = 0;
						foreach (var cell in puzzleTable.Values.ToList()) {
							sPos = rowPos.ToString() + colPos.ToString() + quaPos.ToString();
							if (string.IsNullOrEmpty(cell.Text)) {
								foreach (var number in savedValues[sPos].ToList()) {
									//Check in Quadrant
									foreach (var textbox in arrayQs[quaPos]) {
										if (textbox.Text == number) {
											savedValues[sPos].Remove(number);
										}
									}
									//Check in Rows
									if (savedValues[sPos].Contains(number)) {
										foreach (var textbox in arrayRows[rowPos]) {
											if (textbox.Text == number) {
												savedValues[sPos].Remove(number);
											}
										}
									}
									//Check in Columns
									if (savedValues[sPos].Contains(number)) {
										foreach (var textbox in arrayCols[colPos]) {
											if (textbox.Text == number) {
												savedValues[sPos].Remove(number);
											}
										}
									}
								}
								if (savedValues.Keys.Contains(sPos)) {
									if (savedValues[sPos].Count == 1) {
										cell.Text = savedValues[sPos][0];
									}
								}
							}
							listpositions = updateCounters(rowPos, colPos, quaPos);
							rowPos = listpositions[0];
							colPos = listpositions[1];
							quaPos = listpositions[2];
						}
						counter++;
					} while (counter != 5);

					rowPos = 0;
					colPos = 0;
					quaPos = 0;

					//Check all quads
					Dictionary<int, List<string>> placeholdingKVP = new Dictionary<int, List<string>>();
					for (int x = 0; x < 9; x++) {
						Dictionary<int, List<string>> dictValues = new Dictionary<int, List<string>>();
						foreach (var cell in arrayQs[x]) {
							sPos = rowPos.ToString() + colPos.ToString() + quaPos.ToString();
							if (string.IsNullOrEmpty(cell.Text)) {
								for (int i = 1; i < 10; i++) {
									List<string> listOfCellsWithValue = new List<string>();
									if (savedValues[sPos].ToList().Contains(i.ToString())) {
										listOfCellsWithValue.Add(sPos);
										if (!dictValues.Keys.Contains(i)) {
											dictValues.Add(i, listOfCellsWithValue);
										} else {
											dictValues[i].Add(sPos);
										}
										List<string> tempList = dictValues[i];
										KeyValuePair<int, List<string>> kvpTemp = new KeyValuePair<int, List<string>>(i, tempList);
										if (placeholdingKVP.Keys.Contains(i)) {
											placeholdingKVP[i] = tempList;
										} else {
											placeholdingKVP.Add(kvpTemp.Key, kvpTemp.Value);
										}
									}
								}
							}
							listpositions = updateCounters(rowPos, colPos, quaPos);
							rowPos = listpositions[0];
							colPos = listpositions[1];
							quaPos = listpositions[2];

						}


						foreach (var numberList in placeholdingKVP) {
							if (numberList.Value.Count == 1) {
								puzzleTable[numberList.Value[0]].Text = numberList.Key.ToString();
							}
						}
						placeholdingKVP.Clear();
					}

				} catch (Exception er) {
					label1.Text = er.ToString();
				}

				masterAttempts++;
			} while (masterAttempts != 10);
		}



		#region Methods

		public KeyValuePair<string, List<string>> saveCellPossibleValues(List<int> positions, List<string> values) {
			string combined = positions[0].ToString() + positions[1].ToString() + positions[2].ToString();
			KeyValuePair<string, List<string>> saved = new KeyValuePair<string, List<string>>(combined, values);
			return saved;
		}

		public List<string> findMissingValues(TextBox[] listnums) {
			List<string> listStringNums = new List<string>();
			foreach(var x in listnums) {
				listStringNums.Add(x.Text);
			}
			List<string> missingnums = new List<string>();
			for(int i = 1; i < 10; i++) {
					if (!listStringNums.Contains(i.ToString())) {
						missingnums.Add(i.ToString());
					}
			}
			return missingnums;
		}

		public List<KeyValuePair<int, int>> getMissingCells(List<TextBox[]> list) {
			List<KeyValuePair<int, int>> listEmptyCells = new List<KeyValuePair<int, int>>();
			int iNum = 0;
			int iNum1 = 0;
			foreach (var i in list) {
				foreach (var x in i) {
					if (string.IsNullOrEmpty(x.Text)) {
						listEmptyCells.Add(new KeyValuePair<int, int>(iNum, iNum1));
					}
					iNum1++;
				}
				iNum++;
				iNum1 = 0;
			}
			return listEmptyCells;
		}

		#region Update Counters Method
		public List<int> updateCounters(int row, int col, int quad) {
			List<int> returnlist = new List<int>();
			if (row == 0 && col == 0 && quad == 0) {
				returnlist.Add(0);
				returnlist.Add(1);
				returnlist.Add(0);
			}
			else if (row == 0 && col == 1 && quad == 0) {
				returnlist.Add(0);
				returnlist.Add(2);
				returnlist.Add(0);
			} else if (row == 0 && col == 2 && quad == 0) {
				returnlist.Add(1);
				returnlist.Add(0);
				returnlist.Add(0);
			} else if (row == 1 && col == 0 && quad == 0) {
				returnlist.Add(1);
				returnlist.Add(1);
				returnlist.Add(0);
			} else if (row == 1 && col == 1 && quad == 0) {
				returnlist.Add(1);
				returnlist.Add(2);
				returnlist.Add(0);
			} else if (row == 1 && col == 2 && quad == 0) {
				returnlist.Add(2);
				returnlist.Add(0);
				returnlist.Add(0);
			} else if (row == 2 && col == 0 && quad == 0) {
				returnlist.Add(2);
				returnlist.Add(1);
				returnlist.Add(0);
			} else if (row == 2 && col == 1 && quad == 0) {
				returnlist.Add(2);
				returnlist.Add(2);
				returnlist.Add(0);
			} else if (row == 2 && col == 2 && quad == 0) {
				returnlist.Add(0);
				returnlist.Add(3);
				returnlist.Add(1);
			} else if (row == 0 && col == 3 && quad == 1) {
				returnlist.Add(0);
				returnlist.Add(4);
				returnlist.Add(1);
			} else if (row == 0 && col == 4 && quad == 1) {
				returnlist.Add(0);
				returnlist.Add(5);
				returnlist.Add(1);
			} else if (row == 0 && col == 5 && quad == 1) {
				returnlist.Add(1);
				returnlist.Add(3);
				returnlist.Add(1);
			} else if (row == 1 && col == 3 && quad == 1) {
				returnlist.Add(1);
				returnlist.Add(4);
				returnlist.Add(1);
			} else if (row == 1 && col == 4 && quad == 1) {
				returnlist.Add(1);
				returnlist.Add(5);
				returnlist.Add(1);
			} else if (row == 1 && col == 5 && quad == 1) {
				returnlist.Add(2);
				returnlist.Add(3);
				returnlist.Add(1);
			} else if (row == 2 && col == 3 && quad == 1) {
				returnlist.Add(2);
				returnlist.Add(4);
				returnlist.Add(1);
			} else if (row == 2 && col == 4 && quad == 1) {
				returnlist.Add(2);
				returnlist.Add(5);
				returnlist.Add(1);
			} else if (row == 2 && col == 5 && quad == 1) {
				returnlist.Add(0);
				returnlist.Add(6);
				returnlist.Add(2);
			} else if (row == 0 && col == 6 && quad == 2) {
				returnlist.Add(0);
				returnlist.Add(7);
				returnlist.Add(2);
			} else if (row == 0 && col == 7 && quad == 2) {
				returnlist.Add(0);
				returnlist.Add(8);
				returnlist.Add(2);
			} else if (row == 0 && col == 8 && quad == 2) {
				returnlist.Add(1);
				returnlist.Add(6);
				returnlist.Add(2);
			} else if (row == 1 && col == 6 && quad == 2) {
				returnlist.Add(1);
				returnlist.Add(7);
				returnlist.Add(2);
			} else if (row == 1 && col == 7 && quad == 2) {
				returnlist.Add(1);
				returnlist.Add(8);
				returnlist.Add(2);
			} else if (row == 1 && col == 8 && quad == 2) {
				returnlist.Add(2);
				returnlist.Add(6);
				returnlist.Add(2);
			} else if (row == 2 && col == 6 && quad == 2) {
				returnlist.Add(2);
				returnlist.Add(7);
				returnlist.Add(2);
			} else if (row == 2 && col == 7 && quad == 2) {
				returnlist.Add(2);
				returnlist.Add(8);
				returnlist.Add(2);
			} else if (row == 2 && col == 8 && quad == 2) {
				returnlist.Add(3);
				returnlist.Add(0);
				returnlist.Add(3);
			} else if (row == 3 && col == 0 && quad == 3) {
				returnlist.Add(3);
				returnlist.Add(1);
				returnlist.Add(3);
			} else if (row == 3 && col == 1 && quad == 3) {
				returnlist.Add(3);
				returnlist.Add(2);
				returnlist.Add(3);
			} else if (row == 3 && col == 2 && quad == 3) {
				returnlist.Add(4);
				returnlist.Add(0);
				returnlist.Add(3);
			} else if (row == 4 && col == 0 && quad == 3) {
				returnlist.Add(4);
				returnlist.Add(1);
				returnlist.Add(3);
			} else if (row == 4 && col == 1 && quad == 3) {
				returnlist.Add(4);
				returnlist.Add(2);
				returnlist.Add(3);
			} else if (row == 4 && col == 2 && quad == 3) {
				returnlist.Add(5);
				returnlist.Add(0);
				returnlist.Add(3);
			} else if (row == 5 && col == 0 && quad == 3) {
				returnlist.Add(5);
				returnlist.Add(1);
				returnlist.Add(3);
			} else if (row == 5 && col == 1 && quad == 3) {
				returnlist.Add(5);
				returnlist.Add(2);
				returnlist.Add(3);
			} else if (row == 5 && col == 2 && quad == 3) {
				returnlist.Add(3);
				returnlist.Add(3);
				returnlist.Add(4);
			} else if (row == 3 && col == 3 && quad == 4) {
				returnlist.Add(3);
				returnlist.Add(4);
				returnlist.Add(4);
			} else if (row == 3 && col == 4 && quad == 4) {
				returnlist.Add(3);
				returnlist.Add(5);
				returnlist.Add(4);
			} else if (row == 3 && col == 5 && quad == 4) {
				returnlist.Add(4);
				returnlist.Add(3);
				returnlist.Add(4);
			} else if (row == 4 && col == 3 && quad == 4) {
				returnlist.Add(4);
				returnlist.Add(4);
				returnlist.Add(4);
			} else if (row == 4 && col == 4 && quad == 4) {
				returnlist.Add(4);
				returnlist.Add(5);
				returnlist.Add(4);
			} else if (row == 4 && col == 5 && quad == 4) {
				returnlist.Add(5);
				returnlist.Add(3);
				returnlist.Add(4);
			} else if (row == 5 && col == 3 && quad == 4) {
				returnlist.Add(5);
				returnlist.Add(4);
				returnlist.Add(4);
			} else if (row == 5 && col == 4 && quad == 4) {
				returnlist.Add(5);
				returnlist.Add(5);
				returnlist.Add(4);
			} else if (row == 5 && col == 5 && quad == 4) {
				returnlist.Add(3);
				returnlist.Add(6);
				returnlist.Add(5);
			} else if (row == 3 && col == 6 && quad == 5) {
				returnlist.Add(3);
				returnlist.Add(7);
				returnlist.Add(5);
			} else if (row == 3 && col == 7 && quad == 5) {
				returnlist.Add(3);
				returnlist.Add(8);
				returnlist.Add(5);
			} else if (row == 3 && col == 8 && quad == 5) {
				returnlist.Add(4);
				returnlist.Add(6);
				returnlist.Add(5);
			} else if (row == 4 && col == 6 && quad == 5) {
				returnlist.Add(4);
				returnlist.Add(7);
				returnlist.Add(5);
			} else if (row == 4 && col == 7 && quad == 5) {
				returnlist.Add(4);
				returnlist.Add(8);
				returnlist.Add(5);
			} else if (row == 4 && col == 8 && quad == 5) {
				returnlist.Add(5);
				returnlist.Add(6);
				returnlist.Add(5);
			} else if (row == 5 && col == 6 && quad == 5) {
				returnlist.Add(5);
				returnlist.Add(7);
				returnlist.Add(5);
			} else if (row == 5 && col == 7 && quad == 5) {
				returnlist.Add(5);
				returnlist.Add(8);
				returnlist.Add(5);
			} else if (row == 5 && col == 8 && quad == 5) {
				returnlist.Add(6);
				returnlist.Add(0);
				returnlist.Add(6);
			} else if (row == 6 && col == 0 && quad == 6) {
				returnlist.Add(6);
				returnlist.Add(1);
				returnlist.Add(6);
			} else if (row == 6 && col == 1 && quad == 6) {
				returnlist.Add(6);
				returnlist.Add(2);
				returnlist.Add(6);
			} else if (row == 6 && col == 2 && quad == 6) {
				returnlist.Add(7);
				returnlist.Add(0);
				returnlist.Add(6);
			} else if (row == 7 && col == 0 && quad == 6) {
				returnlist.Add(7);
				returnlist.Add(1);
				returnlist.Add(6);
			} else if (row == 7 && col == 1 && quad == 6) {
				returnlist.Add(7);
				returnlist.Add(2);
				returnlist.Add(6);
			} else if (row == 7 && col == 2 && quad == 6) {
				returnlist.Add(8);
				returnlist.Add(0);
				returnlist.Add(6);
			} else if (row == 8 && col == 0 && quad == 6) {
				returnlist.Add(8);
				returnlist.Add(1);
				returnlist.Add(6);
			} else if (row == 8 && col == 1 && quad == 6) {
				returnlist.Add(8);
				returnlist.Add(2);
				returnlist.Add(6);
			} else if (row == 8 && col == 2 && quad == 6) {
				returnlist.Add(6);
				returnlist.Add(3);
				returnlist.Add(7);
			} else if (row == 6 && col == 3 && quad == 7) {
				returnlist.Add(6);
				returnlist.Add(4);
				returnlist.Add(7);
			} else if (row == 6 && col == 4 && quad == 7) {
				returnlist.Add(6);
				returnlist.Add(5);
				returnlist.Add(7);
			} else if (row == 6 && col == 5 && quad == 7) {
				returnlist.Add(7);
				returnlist.Add(3);
				returnlist.Add(7);
			} else if (row == 7 && col == 3 && quad == 7) {
				returnlist.Add(7);
				returnlist.Add(4);
				returnlist.Add(7);
			} else if (row == 7 && col == 4 && quad == 7) {
				returnlist.Add(7);
				returnlist.Add(5);
				returnlist.Add(7);
			} else if (row == 7 && col == 5 && quad == 7) {
				returnlist.Add(8);
				returnlist.Add(3);
				returnlist.Add(7);
			} else if (row == 8 && col == 3 && quad == 7) {
				returnlist.Add(8);
				returnlist.Add(4);
				returnlist.Add(7);
			} else if (row == 8 && col == 4 && quad == 7) {
				returnlist.Add(8);
				returnlist.Add(5);
				returnlist.Add(7);
			} else if (row == 8 && col == 5 && quad == 7) {
				returnlist.Add(6);
				returnlist.Add(6);
				returnlist.Add(8);
			} else if (row == 6 && col == 6 && quad == 8) {
				returnlist.Add(6);
				returnlist.Add(7);
				returnlist.Add(8);
			} else if (row == 6 && col == 7 && quad == 8) {
				returnlist.Add(6);
				returnlist.Add(8);
				returnlist.Add(8);
			} else if (row == 6 && col == 8 && quad == 8) {
				returnlist.Add(7);
				returnlist.Add(6);
				returnlist.Add(8);
			} else if (row == 7 && col == 6 && quad == 8) {
				returnlist.Add(7);
				returnlist.Add(7);
				returnlist.Add(8);
			} else if (row == 7 && col == 7 && quad == 8) {
				returnlist.Add(7);
				returnlist.Add(8);
				returnlist.Add(8);
			} else if (row == 7 && col == 8 && quad == 8) {
				returnlist.Add(8);
				returnlist.Add(6);
				returnlist.Add(8);
			} else if (row == 8 && col == 6 && quad == 8) {
				returnlist.Add(8);
				returnlist.Add(7);
				returnlist.Add(8);
			} else if (row == 8 && col == 7 && quad == 8) {
				returnlist.Add(8);
				returnlist.Add(8);
				returnlist.Add(8);
			}  else {
				returnlist.Add(0);
				returnlist.Add(0);
				returnlist.Add(0);
			}


			return returnlist;
		}
		#endregion




		#endregion

		#region Clear Button
		private void btnClear_Click(object sender, EventArgs e) {
			tb1.Text = null;
			tb2.Text = null;
			tb3.Text = null;
			tb4.Text = null;
			tb5.Text = null;
			tb6.Text = null;
			tb7.Text = null;
			tb8.Text = null;
			tb9.Text = null;
			tb10.Text = null;
			tb11.Text = null;
			tb12.Text = null;
			tb13.Text = null;
			tb14.Text = null;
			tb15.Text = null;
			tb16.Text = null;
			tb17.Text = null;
			tb18.Text = null;
			tb19.Text = null;
			tb20.Text = null;
			tb21.Text = null;
			tb22.Text = null;
			tb23.Text = null;
			tb24.Text = null;
			tb25.Text = null;
			tb26.Text = null;
			tb27.Text = null;
			tb28.Text = null;
			tb29.Text = null;
			tb30.Text = null;
			tb31.Text = null;
			tb32.Text = null;
			tb33.Text = null;
			tb34.Text = null;
			tb35.Text = null;
			tb36.Text = null;
			tb37.Text = null;
			tb38.Text = null;
			tb39.Text = null;
			tb40.Text = null;
			tb41.Text = null;
			tb42.Text = null;
			tb43.Text = null;
			tb44.Text = null;
			tb45.Text = null;
			tb46.Text = null;
			tb47.Text = null;
			tb48.Text = null;
			tb49.Text = null;
			tb50.Text = null;
			tb51.Text = null;
			tb52.Text = null;
			tb53.Text = null;
			tb54.Text = null;
			tb55.Text = null;
			tb56.Text = null;
			tb57.Text = null;
			tb58.Text = null;
			tb59.Text = null;
			tb60.Text = null;
			tb61.Text = null;
			tb62.Text = null;
			tb63.Text = null;
			tb64.Text = null;
			tb65.Text = null;
			tb66.Text = null;
			tb67.Text = null;
			tb68.Text = null;
			tb69.Text = null;
			tb70.Text = null;
			tb71.Text = null;
			tb72.Text = null;
			tb73.Text = null;
			tb74.Text = null;
			tb75.Text = null;
			tb76.Text = null;
			tb77.Text = null;
			tb78.Text = null;
			tb79.Text = null;
			tb80.Text = null;
			tb81.Text = null;
			label1.Text = null;
		}
		#endregion
	}
}
