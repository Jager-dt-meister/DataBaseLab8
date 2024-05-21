namespace UI.Areas.Admin.Models.ViewModels
{
	public class ClientViewModel
	{
		public SearchResultViewModel<ClientModel> client_model { get; set; }
		public SearchResultViewModel<PurchaseModel> purchase_model { get; set; }
	}
}
