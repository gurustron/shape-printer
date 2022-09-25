using ShapePrinter.Core.Models.Contract;

namespace ShapePrinter.Core.Models;

public sealed record Circle(uint Radius) : IShape
{
    public IEnumerable<string> GetView()
    {
        if (Radius == 0)
        {
            yield break;
            
        }

        var s = @"
 *
* *
 *

  *
 * *
*    *
 * *
  *

   *
  * *
 *   *
*     *
 *   *
  * *
   *

    *
   * *
  *   *
 *     *
*       *
 *     *
  *   *
   * *
    *

     *
    * * 
   *   *
  *     *
 *       *
*      *
 *       *
  *     *
   *   *
    * *
     *

      *
     * *
    *   *
   *     *
  *       *
 *         *
*           *
 *         *
  *       *
   *     *
    *   *
     * *
      *

       *
      * *
     *   *
    *     *
   *       *
  *         *
 *           *
";
        throw new Exception();
        // yield return GetFilledString(Side);
        //
        // if (Side == 1)
        // {
        //     yield break;
        // }
        //
        // for (var i = 1; i < Side - 1; i++)
        // {
        //     yield return GetBorderedString(Side);
        // }
        //
        // yield return GetFilledString(Side);
    }
}