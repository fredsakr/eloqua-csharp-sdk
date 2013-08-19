Eloqua SDK for .NET
=================
A software development kit for .NET that helps developers build applications that integrate with Eloqua.
Currently contains clients for the Bulk API.

## Bulk Client Project
### Create Client
	var info = BulkClient.GetAccountInfo(site, user, password);
	var client = new BulkClient(site, user, password, info.Urls.Apis.Rest.Bulk);

### GET (list)
	List<ContactFilter> filters = _client.ContactFilters.Search(searchTerm, page, count);

### Contact Export
	Export export = new Export
	{
		name = "sample export",
		fields = fields,
		filter = filter,
		secondsToAutoDelete = 3600,
		secondsToRetainData = 3600,
	};

	var exportResult = client.ContactExport.CreateExport(export);

	Sync sync = new Sync
				{
					status = SyncStatusType.pending,
					syncedInstanceUri = exportResult.uri
				};
	var syncResult = _client.ContactExport.CreateSync(sync);

	var data = _client.ContactExport.GetExportData(exportResult.uri);


## License
	Copyright [2013] [Fred Sakr]
	Licensed under the Apache License, Version 2.0 (the "License");
	you may not use this file except in compliance with the License.
	You may obtain a copy of the License at
	http://www.apache.org/licenses/LICENSE-2.0
	Unless required by applicable law or agreed to in writing, software
	distributed under the License is distributed on an "AS IS" BASIS,
	WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	See the License for the specific language governing permissions and
	limitations under the License.
