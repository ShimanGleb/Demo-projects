//
//  CustomTableViewController.swift
//  SwiftTable
//
//  Created by Gleb Shiman on 8/18/16.
//  Copyright © 2016 Gleb Shiman. All rights reserved.
//

import UIKit

class CustomTableViewController: UITableViewController {
    
    var items:[InformationModel] = []
    
    override func viewDidLoad() {
        super.viewDidLoad()
        LoadData()
        // Uncomment the following line to preserve selection between presentations
        // self.clearsSelectionOnViewWillAppear = false

        // Uncomment the following line to display an Edit button in the navigation bar for this view controller.
        // self.navigationItem.rightBarButtonItem = self.editButtonItem()
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }

    // MARK: - Table view data source

    override func numberOfSectionsInTableView(tableView: UITableView) -> Int {
        // #warning Incomplete implementation, return the number of sections
        return 1
    }

    override func tableView(tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        // #warning Incomplete implementation, return the number of rows
        return items.count
    }
    
    override func tableView(tableView: UITableView, cellForRowAtIndexPath indexPath: NSIndexPath) ->UITableViewCell {
        let cellIdentifier = "CustomTableViewCell"
        
        let item = items[indexPath.row]
        
        let cell = tableView.dequeueReusableCellWithIdentifier(cellIdentifier, forIndexPath: indexPath) as! CustomTableViewCell
        cell.dataLabel.text="";
        
        cell.dataImage!.image = UIImage(named: "Loading.gif")
        dispatch_async(dispatch_get_global_queue(DISPATCH_QUEUE_PRIORITY_BACKGROUND, 0), { () -> Void in
            let nSecDispatchTime = dispatch_time(DISPATCH_TIME_NOW, Int64(3.0 * Double(NSEC_PER_SEC)))
            let queue = dispatch_get_main_queue()
            dispatch_after(nSecDispatchTime, queue)
            {
                dispatch_async(dispatch_get_main_queue(), { () -> Void in
                    let cellImage = UIImage(named: item.ImageSource + ".png")
                    cell.dataImage!.image = cellImage
                })
            }
            
        })
        

        
        cell.dataLabel?.text = item.Text
        cell.dataSecondLabel?.text = item.SecondText;
        return cell
    }
    
    
    func LoadData()
    {
        var path = NSBundle.mainBundle().pathForResource("SourceData1", ofType: "txt")
        
        let fm = NSFileManager()
        
        var textData = fm.contentsAtPath(path!)
        
        var cString = NSString(data: textData!, encoding: NSUTF8StringEncoding) as! String
        var lines = cString.characters.split{$0 == "\n"}.map(String.init)
        
        for i in 0...lines.count-1
        {
            let model = InformationModel(TextLine: lines[i])
            model.ImageSource=String(i%2+1);
            items.append(model)
        }
        
        path = NSBundle.mainBundle().pathForResource("SourceData2", ofType: "txt")
        
        textData = fm.contentsAtPath(path!)
        
        cString = NSString(data: textData!, encoding: NSUTF8StringEncoding) as! String
        lines = cString.characters.split{$0 == "\n"}.map(String.init)
        
        for i in 0...lines.count-1
        {
            items[i].SecondText = lines[i]
        }
    }
    /*
    override func tableView(tableView: UITableView, cellForRowAtIndexPath indexPath: NSIndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCellWithIdentifier("reuseIdentifier", forIndexPath: indexPath)

        // Configure the cell...

        return cell
    }
    */

    /*
    // Override to support conditional editing of the table view.
    override func tableView(tableView: UITableView, canEditRowAtIndexPath indexPath: NSIndexPath) -> Bool {
        // Return false if you do not want the specified item to be editable.
        return true
    }
    */

    /*
    // Override to support editing the table view.
    override func tableView(tableView: UITableView, commitEditingStyle editingStyle: UITableViewCellEditingStyle, forRowAtIndexPath indexPath: NSIndexPath) {
        if editingStyle == .Delete {
            // Delete the row from the data source
            tableView.deleteRowsAtIndexPaths([indexPath], withRowAnimation: .Fade)
        } else if editingStyle == .Insert {
            // Create a new instance of the appropriate class, insert it into the array, and add a new row to the table view
        }    
    }
    */

    /*
    // Override to support rearranging the table view.
    override func tableView(tableView: UITableView, moveRowAtIndexPath fromIndexPath: NSIndexPath, toIndexPath: NSIndexPath) {

    }
    */

    /*
    // Override to support conditional rearranging of the table view.
    override func tableView(tableView: UITableView, canMoveRowAtIndexPath indexPath: NSIndexPath) -> Bool {
        // Return false if you do not want the item to be re-orderable.
        return true
    }
    */

    /*
    // MARK: - Navigation

    // In a storyboard-based application, you will often want to do a little preparation before navigation
    override func prepareForSegue(segue: UIStoryboardSegue, sender: AnyObject?) {
        // Get the new view controller using segue.destinationViewController.
        // Pass the selected object to the new view controller.
    }
    */

}
