namespace UI.Areas.Admin.Models.ViewModels
{
	public class GymsViewModel
	{
		public SearchResultViewModel<EquipmentModel> eq_model { get; set; }
		public SearchResultViewModel<GymModel> gym_model { get; set; }
	}
}
