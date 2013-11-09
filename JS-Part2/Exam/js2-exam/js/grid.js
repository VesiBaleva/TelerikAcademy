
var controls = (function() {

  

  function GridView(selector) {
    var items = [];
    var gridViewItem = document.querySelector(selector);

    var itemsList = document.createElement("table");

    this.addHeader = function(title) {
      
      var temp=[];      
      for(var i=0;i<4;i++)
      {
        temp[i]=arguments[i];
        var newItem = new GridViewRow(temp[i]);
        items.push(newItem);
      }

      
      
      return newItem;
    };



    this.addRow = function(title) {
      
      var temp=[];      
      for(var i=0;i<4;i++)
      {
        temp[i]=arguments[i];
        var newItem = new GridViewRow(temp[i]);
        items.push(newItem);
      }

      
      
      return newItem;
    };

    this.render = function() {
      while (gridViewItem.firstChild) {
        gridViewItem.removeChild(gridViewItem.firstChild);
      }

      while (itemsList.firstChild) {
        itemsList.removeChild(itemsList.firstChild);
      }

      
      
      for (var i = 0, len = items.length; i < len; i += 4) {
        
        var itemNode = document.createElement("tr");
          for (var j=0;j<4;j+=1) {


            var domItem = items[i+j].render();
            itemsList.appendChild(domItem);
          }
        

        
        itemsList.appendChild(itemNode);
      }

      
      gridViewItem.appendChild(itemsList);
      return this;
    };

    
  };

  function GridViewRow(title) {
    


      var items = [];
    /*  this.add = function(title) {
        var newItem = new Item(title);
        items.push(newItem);
        return newItem;
      };*/

      this.render = function() {
        var itemNode = document.createElement("td");

        itemNode.innerHTML = title ;

        return itemNode;
    };

  }

  

  return {
    getGridView: function(selector) {
      return new GridView(selector);
    },
    getNestedGridView: function(title) {
      return new GridView(selector);
    }
  }
}());
