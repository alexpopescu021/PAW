// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function loadServerPartialView(container, baseUrl) {
    return $.get(baseUrl, function (responseData) {
        $(container).html(responseData);
        var dataSrc = [];

        var table = $('#Songs').DataTable({
            'initComplete': function () {
                var api = this.api();

                // Populate a dataset for autocomplete functionality
                // using data from first, second and third columns
                api.cells('tr', [0, 1, 2]).every(function () {
                    // Get cell data as plain text
                    var data = $('<div>').html(this.data()).text();
                    if (dataSrc.indexOf(data) === -1) { dataSrc.push(data); }
                });

                // Sort dataset alphabetically
                dataSrc.sort();

                // Initialize Typeahead plug-in
                $('.dataTables_filter input[type="search"]', api.table().container())
                    .typeahead({
                        source: dataSrc,
                        afterSelect: function (value) {
                            api.search(value).draw();
                        }
                    }
                    );
            }
        });

    });
}
