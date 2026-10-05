using ErrorOr;
using PharmaPOS.Domain.Common;

namespace PharmaPOS.Domain.MediaAggregate;

public class Media : AggregateRoot
{
	// EF Core parameterless constructor
	private Media() { }

	private Media(string filename, string ext, DateTime createdDate)
	{
		Filename = filename;
		Ext = ext;
		CreatedDate = createdDate;
	}

	public static ErrorOr<Media> Create(string filename, string ext, DateTime createdDate)
	{
		var errors = new List<Error>();
		
		// Standard DomainValidator approach
		DomainValidator<Media>.ValidateRequiredStrings(errors,
			(filename, nameof(filename)),
			(ext, nameof(ext))
		);

		if (errors.Count != 0)
		{
			return errors;
		}

		return new Media(filename, ext, createdDate);
	}

	public string Filename { get; private set; } = null!;
	public string Ext { get; private set; } = null!;
	
	public DateTime CreatedDate { get; private init; }
}
