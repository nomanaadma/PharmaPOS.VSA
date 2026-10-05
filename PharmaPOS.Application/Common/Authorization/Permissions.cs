using System.Reflection;

namespace PharmaPOS.Application.Common.Authorization;

public static class Permissions
{
	
    public static class Dashboard
    {
		public const string View = "dashboard";
		public const string ViewLabel = "Dashboard";
		
    }

    public static class Customer
    {
		public const string List = "customers";
		public const string ListLabel = "Customers List";
		
		public const string Add = "customer/add";
		public const string AddLabel = "Customer Add";
		
		public const string Edit = "customer/edit";
		public const string EditLabel = "Customer Edit";
		
		public const string Delete = "customer/delete";
		public const string DeleteLabel = "Customer Delete";
		
		public const string View = "customer/view";
		public const string ViewLabel = "Customer View";
		
    }

    public static class Billing
    {
	    public const string Name = "POS/Bill";
	    
		public const string List = "medicine/billing";
		public const string ListLabel = "POS/Bill List";
		
		public const string Add = "medicine/billing/add";
		public const string AddLabel = "Bill Add";
		
		public const string Edit = "medicine/billing/edit";
		public const string EditLabel = "Bill Edit";
		
		public const string Delete = "medicine/billing/delete";
		public const string DeleteLabel = "Bill Delete";
		
		public const string View = "medicine/billing/view";
		public const string ViewLabel = "Bill View";
		
    }

    public static class Purchase
    {
		public const string List = "medicine/purchase";
		public const string ListLabel = "Purchase List";
		
		public const string Add = "medicine/purchase/add";
		public const string AddLabel = "Purchase Add";
		
		public const string Edit = "medicine/purchase/edit";
		public const string EditLabel = "Purchase Edit";
		
		public const string Delete = "medicine/purchase/delete";
		public const string DeleteLabel = "Purchase Delete";
		
		public const string View = "medicine/purchase/view";
		public const string ViewLabel = "Purchase View";
		
    }

    public static class Stock
    {
	    public const string Name = "Stock Adjustment";
	    
		public const string View = "medicine/stock";
		public const string ViewLabel = "Stock List";
		
		public const string Delete = "medicine/stock/delete";
		public const string DeleteLabel = "Stock Delete";
		
    }

    public static class Medicine
    {
		public const string List = "medicines";
		public const string ListLabel = "Medicine List";
		
		public const string Add = "medicine/add";
		public const string AddLabel = "Medicine Add";
		
		public const string Edit = "medicine/edit";
		public const string EditLabel = "Medicine Edit";
		
		public const string Delete = "medicine/delete";
		public const string DeleteLabel = "Medicine Delete";
		
		public const string View = "medicine/view";
		public const string ViewLabel = "Medicine View";
		
    }

    public static class Category
    {
	    public const string Name = "Medicine Category";
	    
		public const string List = "medicine/category";
		public const string ListLabel = "Medicine Category List";
		
		public const string Add = "medicine/category/add";
		public const string AddLabel = "Medicine Category Add";
		
		public const string Edit = "medicine/category/edit";
		public const string EditLabel = "Medicine Category Edit";
		
		public const string Delete = "medicine/category/delete";
		public const string DeleteLabel = "Medicine Category Delete";
		
    }
    
    public static class Reports
    {
		public const string View = "reports";
		public const string ViewLabel = "All Reports";
		
    }
    
    public static class User
    {
		public const string List = "users";
		public const string ListLabel = "User List";
		
		public const string Add = "user/add";
		public const string AddLabel = "User Add";
		
		public const string Edit = "user/edit";
		public const string EditLabel = "User Edit";
		
		public const string Delete = "user/delete";
		public const string DeleteLabel = "User Delete";
		
    }
    
    public static class Info
    {
	    public const string Name = "System Info";

		public const string View = "info";
		public const string ViewLabel = "System Info";
		
    }
    

    public static class PaymentMethod
    {
	    public const string Name = "Payment Method";
	    
		public const string List = "paymentmethod";
		public const string ListLabel = "Payment Methods";
		
		public const string Add = "paymentmethod/add";
		public const string AddLabel = "Payment Method Add";
		
		public const string Edit = "paymentmethod/edit";
		public const string EditLabel = "Payment Method Edit";
		
		public const string Delete = "paymentmethod/delete";
		public const string DeleteLabel = "Payment Method Delete";
		
    }

    public static class Media
    {
		public const string List = "get/media";
		public const string ListLabel = "Media on Modal";
		
		public const string Upload = "media/upload";
		public const string UploadLabel = "Media Upload";
		
		public const string Delete = "media/delete";
		public const string DeleteLabel = "Media Delete";
		
    }
    
    public static class Suppliers
    {
		public const string List = "suppliers";
		public const string ListLabel = "Suppliers List";
		
		public const string Add = "supplier/add";
		public const string AddLabel = "Supplier Add";
		
		public const string Edit = "supplier/edit";
		public const string EditLabel = "Supplier Edit";
		
		public const string Delete = "supplier/delete";
		public const string DeleteLabel = "Supplier Delete";
		
    }
   
    
    public static string[] GetAll()
    {
	    return typeof(Permissions)
		    .GetNestedTypes(BindingFlags.Public)
		    .SelectMany(Get)
		    .ToArray();
    }
    
    public static string[] Get(Type group)
    {
	    return group.GetFields(BindingFlags.Public | BindingFlags.Static)
		    // 1. Must be a constant (IsLiteral) and a string
		    .Where(f => f.IsLiteral && f.FieldType == typeof(string))
		    // 2. Ignore the group "Name" and any field ending in "Label"
		    .Where(f => f.Name != "Name" && !f.Name.EndsWith("Label"))
		    // 3. Extract the value
		    .Select(f => (string)f.GetValue(null)!)
		    .ToArray();
    }
    
    public static string[] Get(params Type[] groups)
    {
	    return groups
		    .SelectMany(Get)
		    .ToArray();
    }
    
    public static Dictionary<string, Dictionary<string, string>> GetPermissionsTemplate()
    {
	    var roles = new Dictionary<string, Dictionary<string, string>>();
	    var nestedTypes = typeof(Permissions).GetNestedTypes(BindingFlags.Public);

	    foreach (var groupType in nestedTypes)
	    {
		    // 1. Get Group Name (Template {{ key }})
		    string groupName = groupType.Name; 
		    var nameConstant = groupType.GetField("Name", BindingFlags.Public | BindingFlags.Static);
		    if (nameConstant != null && nameConstant.IsLiteral && nameConstant.FieldType == typeof(string))
		    {
			    groupName = (string)nameConstant.GetValue(null)!;
		    }

		    // 2. Pair keys with their labels
		    var permissionsDictionary = new Dictionary<string, string>();
        
		    var allConstants = groupType.GetFields(BindingFlags.Public | BindingFlags.Static)
			    .Where(f => f.IsLiteral && f.FieldType == typeof(string))
			    .ToList();

		    // Get only the keys (ignore "Name" and "...Label")
		    var keyFields = allConstants.Where(f => f.Name != "Name" && !f.Name.EndsWith("Label"));

		    foreach (var keyField in keyFields)
		    {
			    var key = (string)keyField.GetValue(null)!;
            
			    // Try to find the matching Label field (e.g., "List" -> "ListLabel")
			    var labelField = allConstants.FirstOrDefault(f => f.Name == keyField.Name + "Label");
			    var label = labelField != null ? (string)labelField.GetValue(null)! : key;

			    // Template {{ sub_key }} = key
			    // Template {{ sub_value }} = label
			    permissionsDictionary.Add(key, label);
		    }

		    if (permissionsDictionary.Count > 0)
		    {
			    roles.Add(groupName, permissionsDictionary);
		    }
	    }

	    return roles;
    }
    
}