$(function () {

    //Set the hubs URL for the connection
    $.connection.hub.url = "http://localhost:8080/signalr";

    // Declare a proxy to reference the hub.
    var stockQuotes = $.connection.stockQuoteHub;

    var symbolEl = document.getElementById('symbol');
    var askEl = document.getElementById('ask');
    // Create a function that the hub can call to broadcast messages.
    stockQuotes.client.updateStocks = function (stockQuotesCollection) {stockQuotes
        upsertStockEements(stockQuotesCollection);
    };

    $.connection.hub.logging = true;
    $.connection.hub
        .start({ transport: ['webSockets', 'serverSentEvents', 'longPolling'] })
        .done(function () {
            var addStockBtn = document.getElementById('add-stock-btn');

            addStockBtn.addEventListener('click', function () {
                var stockNameInput = document.getElementById('stock-name-input');

                if (stockNameInput) {
                    stockQuotes.server.updateCallerStockQuotes(stockNameInput.value);
                }
            });
        });
});

function upsertStockEements(stockQuotesCollection) {
    stockQuotesCollection.forEach(function (item) {
        if (item.Ask && item.Symbol) {
            var quoteContainerId = 'stockQuotes-tbl';
            var quoteRowElementId = 'stock-quotes-row-' + item.Symbol;
            var quoteNameElementId = 'quote-name-' + item.Symbol;
            var quoteValueElementId = 'quote-value-' + item.Symbol;

            var stockQouteContainer = document.getElementById(quoteContainerId);
            var stockQuoteRow = document.getElementById(quoteRowElementId);

            if (stockQuoteRow) {
                var nameElement = document.getElementById(quoteNameElementId);
                var valueElement = document.getElementById(quoteValueElementId);
            }
            else {
                var tableRow = document.createElement('tr');
                tableRow.id = quoteRowElementId;
                var nameElement = document.createElement('td');
                nameElement.id = quoteNameElementId;
                var valueElement = document.createElement('td');
                valueElement.id = quoteValueElementId;

                tableRow.appendChild(nameElement);
                tableRow.appendChild(valueElement)
                stockQouteContainer && stockQouteContainer.appendChild(tableRow);
            }

            nameElement.innerHTML = item.Symbol;
            valueElement.innerHTML = item.Ask;
        }
    });
}
