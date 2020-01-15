/// <reference path="jsColumns.js" />
function GetCol(tbl) {
    switch (tbl) {
        case "GameList":
            return [
                
                { title: "Id", data: "ProductId", visible: false },
                { title: "Game", data: "Title" },
                { title: "Rating", data: "Rating" },
                { title: "Condition", data: "Condition" },
                { title: "Platform", data: "Platform" },
                { title: "Act. Price", data: "ActualPrice" },
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

                { title: "Id", data: "ProductId", visible: false },
                { title: "Product", data: "Title" },
                { title: "Rating", data: "Rating" },
                { title: "Condition", data: "Condition" },
                { title: "Category", data: "Category" },
                { title: "Platform", data: "Platform" },
                { title: "Price", data: "ActualPrice" },
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

                { title: "Id", data: "ProductId", visible: false},
                { title: "Product", data: "Title" },
                { title: "Rating", data: "Rating" },
                { title: "Condition", data: "Condition" },
                { title: "Category", data: "Category" },
                { title: "Platform", data: "Platform" },
                { title: "Act. Price", data: "ActualPrice" },
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

                { title: "Id", data: "ExchangeId", visible: false},
                { title: "Game", data: "Title" },
                { title: "Platform", data: "Platform" },
                { title: "Store Price", data: "StorePrice" },
                { title: "Buying Price", data: "BuyingPrice" },
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
        case "OrderList":
            return [

                { title: "Id", data: "OrderId", visible: false },
                //{ title: "Date", data: "Date" },
                { title: "First Name", data: "FirstName" },
                { title: "Last Name", data: "LastName" },
                { title: "Phone", data: "Phone" },
                { title: "Email", data: "Email" },
                { title: "Payment", data: "Total" },
                //{ title: "Status", data: "Status" },
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