using System.Runtime.Serialization;
using Elasticsearch.Net.Utf8Json;

namespace Nest
{
	/// <summary>
	/// A snapshot lifecycle policy
	/// </summary>
	public class SnapshotLifecyclePolicy
		: ISnapshotLifecyclePolicy
	{
		/// <inheritdoc />
		public ISnapshotLifecycleConfig Config { get; set; }

		/// <inheritdoc />
		public string Name { get; set; }

		/// <inheritdoc />
		public string Repository { get; set; }

		/// <inheritdoc />
		public CronExpression Schedule { get; set; }
	}

	/// <inheritdoc />
	[InterfaceDataContract]
	[ReadAs(typeof(SnapshotLifecyclePolicy))]
	public interface ISnapshotLifecyclePolicy
	{
		/// <summary>
		/// Configuration for each snapshot that will be created by this policy.
		/// </summary>
		[DataMember(Name = "config")]
		ISnapshotLifecycleConfig Config { get; set; }

		/// <summary>
		/// A name automatically given to each snapshot performed by this policy.
		/// Supports the same date math supported in index names. A UUID is automatically appended to the
		/// end of the name to prevent conflicting snapshot names.
		/// </summary>
		[DataMember(Name = "name")]
		string Name { get; set; }

		/// <summary>
		/// The snapshot repository that will contain snapshots created by this policy.
		/// The repository must exist prior to the policy’s creation and can be created
		/// with the Snapshot CreateRespository API.
		/// </summary>
		[DataMember(Name = "repository")]
		string Repository { get; set; }

		/// <summary>
		/// A periodic or absolute time schedule specified as a cron expression.
		/// </summary>
		[DataMember(Name = "schedule")]
		CronExpression Schedule { get; set; }
	}
}
