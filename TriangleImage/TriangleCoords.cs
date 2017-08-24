using System;

namespace TriangleImage
{
    public class TriangleCoords
    {
        /// <summary>
        /// Accepts row indicator as char (A-F), int col val (1-12), and hypotenuse length and returns
        /// the triangle vertices for the right triangle in the target position (in a matrix) such that
        /// the matrix forms a full square image of right triangles. Each element in the resulting matrix 
        /// is assumed to be one square pixel and each non hypotenuse side has length = nonHypoLen
        /// </summary>
        /// <returns>
        /// A Triangle object with three vertices ordered st. v1 is top left vertex
        /// and v2/v3 are the next vertices moving clockwise from v1.
        /// </returns>
        public static Triangle CalcTriangleCoords(TriangleLocation loc, int nonHypoLen) 
        {
            if (loc.Row < 'A' || loc.Row > 'F' || loc.Col < 1 || loc.Col > 12 || nonHypoLen < 1) {
                throw new Exception("inputs outside of acceptable range for triangle coord calculation"); 
            }

            int rowVal = loc.Row - 'A'; 

            Triangle t = new Triangle(); 
            
            // v1.a will be in same place regardless of triangle orientation
            t.V1.Row = rowVal * nonHypoLen; 

            // calculate other vertices based on triangle orientation
            if (loc.Col % 2 == 0) 
            {
                int colIndx = loc.Col / 2 - 1; 
                t.V1.Col = colIndx * nonHypoLen; 
                t.V2.Row = rowVal * nonHypoLen; 
                t.V2.Col = (colIndx + 1) * nonHypoLen; 
                t.V3.Row = (rowVal + 1) * nonHypoLen; 
                t.V3.Col = (colIndx + 1) * nonHypoLen; 
            }
            else 
            {
                int colIndx = loc.Col / 2; 
                t.V1.Col = colIndx * nonHypoLen; 
                t.V2.Row = (rowVal + 1) * nonHypoLen; 
                t.V2.Col = (colIndx + 1) * nonHypoLen; 
                t.V3.Row = (rowVal + 1) * nonHypoLen; 
                t.V3.Col = colIndx * nonHypoLen; 
            }

            return t; 
        }

        /// <summary>
        /// Accepts right Triangle formed by three vertices such that each non hypotenuse side is 
        /// of length nonHypoLen
        /// </summary>
        /// <returns> TriangleLocation containing char row (A-F) and int col (1-12) specifying where triangle is located in image</returns>
        public static TriangleLocation CalcRowAndCol(Triangle t, int nonHypoLen)
        {
            if (t == null || nonHypoLen < 1) 
            {
                throw new Exception("bad inputs.");
            }

            // vertices ordered with lowest row indx first
            Triangle.TriangleVertex[] orderedVs = new Triangle.TriangleVertex[3]; 
            if (t.V1.Row <= t.V2.Row) 
            {
                orderedVs[0] = t.V1; 

                if (t.V2.Row <= t.V3.Row)
                {
                    orderedVs[1] = t.V2; 
                    orderedVs[2] = t.V3; 
                }
                else 
                {
                    orderedVs[1] = t.V3; 
                    orderedVs[2] = t.V2; 
                }
            }
            else 
            {
                orderedVs[0] = t.V2; 

                if (t.V1.Row <= t.V3.Row)
                {
                    orderedVs[1] = t.V1;
                    orderedVs[2] = t.V3; 
                }
                else
                {
                    orderedVs[1] = t.V3; 
                    orderedVs[2] = t.V1; 
                }
            }

            if (orderedVs[1].Row < orderedVs[0].Row)
            {
                Triangle.TriangleVertex temp = orderedVs[1]; 
                orderedVs[1] = orderedVs[0]; 
                orderedVs[0] = temp; 
            }

            char row = (char)((int)'A' + (orderedVs[0].Row / nonHypoLen)); 
            if (orderedVs[0].Row == orderedVs[1].Row)
            {
                // triangle orientaion: 
                // -----
                //  \  |
                //    \|
                if (orderedVs[1].Col > orderedVs[0].Col)
                {
                    return new TriangleLocation(row, 
                                        orderedVs[1].Col / nonHypoLen * 2);                    
                }
                else
                {
                    return new TriangleLocation(row, 
                                        orderedVs[0].Col / nonHypoLen * 2); 
                }

            }
            else
            {
                // triangle orientation: 
                // | \
                // |__\
                if (orderedVs[2].Col > orderedVs[1].Col) 
                {
                    return new TriangleLocation(row, orderedVs[2].Col / nonHypoLen * 2 - 1); 
                }
                else 
                {
                    return new TriangleLocation(row, orderedVs[1].Col / nonHypoLen * 2 - 1); 
                }
            }

        }


        public class TriangleLocation
        {

            public TriangleLocation() {}

            public TriangleLocation(char row, int col) 
            {
                Row = row; 
                Col = col; 
            }

            public char Row { get; set; }

            public int Col {get; set; }
        }
    }
}
