# Easy Sort
A simple way to sort LINQ IQueryables when, for example, you have multiple columns in a table and you'd like to provide support for asc/desc sorting on many of them.

## Example usage


```csharp
private static EasySort<Project> ProjectEasySort = new EasySort<Project>()
                                                   .Map("site",      e => e.Site.Name)
                                                   .Map("name",      e => e.Name)
                                                   .Map("category",  e => e.Category.Name)
                                                   .Map("creator",   e => e.Creator.FirstName)
                                                   .Map("modified",  e => e.DateModified);


public IList<Project> List(int categoryId, string sortKey, Order sortOrder)
{
  var query = Context.Project.Where(e => e.CategoryId == categoryId);
  
  return ProjectEasySort.Sort(query, sortKey, sortOrder).ToList();
}
```
