/// <reference path="jsColumns.js" />
function GetCol(tbl) {
    switch (tbl) {
        case "GameList":
            return [
                
                { title: "Id", data: "ProductId" },
                { title: "Game", data: "Title" },
                { title: "Rating", data: "Rating" },
                { title: "Condition", data: "Condition" },
                { title: "Platform", data: "Platform" },
                { title: "Tags", data: "tags" },
                { title: "Act. Price", data: "ActualPrice" },
                { title: "Dis. Price", data: "DiscountedPrice" },
                {
                    title: "Images",
                    data: null,
                    render: function (data, type, row) {
                        btnview = "";
                        btnview = '<button onclick="ShowImages(this)" class="btn btn-outline-primary"> Images</button>';

                        return btnview;
                    },
                    width: "100px",
                    sortable: false,
                    className: "text-center"
                },
                {
                    title: "Action",
                    data: null,
                    render: function (data, type, row) {
                        btnview = "";
                        btnview = '<button onclick="OnGridEdit(this)" class="btn btn-outline-primary"> Edit</button>';
                        btnview = btnview + '&nbsp;<button onclick="OnGridDelete(this)" class="btn btn-outline-primary"> Delete</button>';
                        return btnview;
                    },
                    width: "100px",
                    sortable: false,
                    className: "text-center"
                }
            ];
        case "AccessoriesList":
            return [

                { title: "Id", data: "ProductId" },
                { title: "Product", data: "Title" },
                { title: "Rating", data: "Rating" },
                { title: "Condition", data: "Condition" },
                { title: "Category", data: "Category" },
                { title: "Platform", data: "Platform" },
                { title: "Tags", data: "tags" },
                { title: "Act. Price", data: "ActualPrice" },
                { title: "Dis. Price", data: "DiscountedPrice" },
                {
                    title: "Images",
                    data: null,
                    render: function (data, type, row) {
                        btnview = "";
                        btnview = '<button onclick="ShowImages(this)" class="btn btn-outline-primary"> Images</button>';

                        return btnview;
                    },
                    width: "100px",
                    sortable: false,
                    className: "text-center"
                },
                {
                    title: "Action",
                    data: null,
                    render: function (data, type, row) {
                        btnview = "";
                        btnview = '<button onclick="OnGridEdit(this)" class="btn btn-outline-primary"> Edit</button>';
                        btnview = btnview + '&nbsp;<button onclick="OnGridDelete(this)" class="btn btn-outline-primary"> Delete</button>';
                        return btnview;
                    },
                    width: "100px",
                    sortable: false,
                    className: "text-center"
                }
                
               
            ];
        case "ConsolesList":
            return [

                { title: "Id", data: "ProductId" },
                { title: "Product", data: "Title" },
                { title: "Rating", data: "Rating" },
                { title: "Condition", data: "Condition" },
                { title: "Category", data: "Category" },
                { title: "Platform", data: "Platform" },
                { title: "Tags", data: "tags" },
                { title: "Act. Price", data: "ActualPrice" },
                { title: "Dis. Price", data: "DiscountedPrice" },
                {
                    title: "Images",
                    data: null,
                    render: function (data, type, row) {
                        btnview = "";
                        btnview = '<button onclick="ShowImages(this)" class="btn btn-outline-primary"> Images</button>';

                        return btnview;
                    },
                    width: "100px",
                    sortable: false,
                    className: "text-center"
                },
                {
                    title: "Action",
                    data: null,
                    render: function (data, type, row) {
                        btnview = "";
                        btnview = '<button onclick="OnGridEdit(this)" class="btn btn-outline-primary"> Edit</button>';
                        btnview = btnview + '&nbsp;<button onclick="OnGridDelete(this)" class="btn btn-outline-primary"> Delete</button>';
                        return btnview;
                    },
                    width: "100px",
                    sortable: false,
                    className: "text-center"
                }

            ];
        case "ExchangeList":
            return [

                { title: "Id", data: "ExchangeId" },
                { title: "Requested By", data: "ClientName" },
                { title: "Requested Title", data: "ClientGame" },
                { title: "Store Title", data: "StoreGame" },
                { title: "Payment", data: "Payment" },
                { title: "Platform", data: "Type" },
                {
                    title: "Action",
                    data: null,
                    render: function (data, type, row) {
                        btnview = "";
                        btnview = '<button onclick="OnGridEdit(this)" class="btn btn-outline-primary"> View</button>';
                        btnview = btnview + '&nbsp;<button onclick="OnGridDelete(this)" class="btn btn-outline-primary"> Delete</button>';
                        return btnview;
                    },
                    width: "100px",
                    sortable: false,
                    className: "text-center"
                }

            ];
        default:
            return [];

    }
}