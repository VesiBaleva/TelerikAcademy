    if (!document.querySelectorAll) { 
            document.querySelectorAll = function (selector) {
                var head = document.documentElement.firstChild; // takes <head> tag
                var styleTag = document.createElement("STYLE"); // creates a new <style> tag
                head.appendChild(styleTag);
                document.arrayOfSelectorNodes = [];
 
                // the next line is the magic - so called IE5-IE7 CSS expressions:
                //    the expression is executed on each HTML element that fulfils the selector  
                styleTag.styleSheet.cssText = selector + "{x:expression(document.arrayOfSelectorNodes.push(this))}";
                // the next line forces DOM tree to reload and CCS to execute
                window.scrollBy(1, 0);
                head.removeChild(styleTag);
                window.scrollBy(-1, 0);
                return document.arrayOfSelectorNodes;
            }
        }