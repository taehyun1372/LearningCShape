using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _79_PaginationHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Something happened");
            var helper = new PaginationHelper<char>(new List<Char>() { 'a', 'b', 'c', 'd'}, 4);

            Console.WriteLine(helper.PageCount);
            Console.WriteLine(helper.ItemCount);
            Console.WriteLine(helper.PageItemCount(0));
            Console.WriteLine(helper.PageItemCount(1));
            Console.WriteLine(helper.PageItemCount(2));

            Console.WriteLine(helper.PageIndex(5));
            Console.WriteLine(helper.PageIndex(2));
            Console.WriteLine(helper.PageIndex(20));
            Console.WriteLine(helper.PageIndex(-10));

            Console.ReadLine();
        }
    }
}
public class PaginationHelper<T>
{
    // TODO: Complete this class
    private IList<T> _collection;
    private int _itemsPerPage;
    private int[] _itemCount;

    /// <summary>
    /// Constructor, takes in a list of items and the number of items that fit within a single page
    /// </summary>
    /// <param name="collection">A list of items</param>
    /// <param name="itemsPerPage">The number of items that fit within a single page</param>
    public PaginationHelper(IList<T> collection, int itemsPerPage)
    {
        _collection = collection;
        _itemsPerPage = itemsPerPage;

        _itemCount = new int[PageCount];
        for (int i = 0; i < PageCount; i++)
        {
            if (i < PageCount - 1)
            {
                _itemCount[i] = itemsPerPage;
            }
            else
            {
                _itemCount[i] = _collection.Count() - itemsPerPage * i;
            }
        }
    }

    /// <summary>
    /// The number of items within the collection
    /// </summary>
    public int ItemCount
    {
        get
        {
            return _collection.Count();
        }
    }

    /// <summary>
    /// The number of pages
    /// </summary>
    public int PageCount
    {
        get
        {
            return (int)Math.Ceiling((double)_collection.Count() / _itemsPerPage);
        }
    }

    /// <summary>
    /// Returns the number of items in the page at the given page index 
    /// </summary>
    /// <param name="pageIndex">The zero-based page index to get the number of items for</param>
    /// <returns>The number of items on the specified page or -1 for pageIndex values that are out of range</returns>
    public int PageItemCount(int pageIndex)
    {
        if (pageIndex > -1 && pageIndex < _itemCount.Count())
        {
            return _itemCount[pageIndex];
        }
        else
        {
            return -1;
        }
    }

    /// <summary>
    /// Returns the page index of the page containing the item at the given item index.
    /// </summary>
    /// <param name="itemIndex">The zero-based index of the item to get the pageIndex for</param>
    /// <returns>The zero-based page index of the page containing the item at the given item index or -1 if the item index is out of range</returns>
    public int PageIndex(int itemIndex)
    {
        if (itemIndex > -1 && itemIndex < ItemCount)
        {
            return (int)Math.Ceiling((double)(itemIndex + 1) / _itemsPerPage) - 1;
        }
        else
        {
            return -1;
        }
        
    }
}