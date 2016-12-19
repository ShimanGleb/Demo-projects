//
//  InformationModel.swift
//  SwiftTable
//
//  Created by Gleb Shiman on 8/18/16.
//  Copyright © 2016 Gleb Shiman. All rights reserved.
//

import Foundation

class InformationModel {
    
    var Text:String = ""
    
    var SecondText:String=""
    
    var ImageSource:String = ""
    
    init(TextLine text: String)
    {
        Text = text
        ImageSource = String(arc4random_uniform(2)+1)
    }
    
}