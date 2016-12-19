//
//  ViewController.swift
//  BallBreakerSwift
//
//  Created by Gleb Shiman on 8/10/16.
//  Copyright © 2016 Gleb Shiman. All rights reserved.
//

import UIKit

class ViewController: UIViewController {

    var ballImage: UIImageView?
    var rectangleImage: UIImageView?
    
    var timer: NSTimer?
    
    var directionX : CGFloat = 1;
    var directionY : CGFloat = 1;
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        title = "BALL BREAKER!";
        
        LoadElements()
    }
    
    func LoadElements()
    {
        ballImage = UIImageView(frame: CGRectMake(20, 400, 100, 150))
        
        let round = UIImage(named: "Round.png")
        ballImage!.image = round
        
        var ballFrame = ballImage?.frame;
        
        var size = ballFrame!.size;
        size.height = 40;
        size.width = 40;
        ballFrame!.size = size;
        
        ballImage!.frame = ballFrame!;
        ballImage!.center = CGPoint(x: 100, y: 100);
        
        view.addSubview(ballImage!);
        
        rectangleImage = UIImageView(frame: CGRectMake(20, 400, 100, 150))
        
        let rectangle = UIImage(named: "Rectangle.png")
        rectangleImage!.image = rectangle
        var rectangleFrame = rectangleImage!.frame;
        
        size = rectangleFrame.size;
        size.height = 20;
        size.width = 100;
        rectangleFrame.size = size;
        
        rectangleImage!.frame = rectangleFrame;
        rectangleImage!.center = CGPoint(x: view.bounds.size.width * 0.4,
                                         y: view.bounds.size.height - rectangleImage!.bounds.size.height - 20);
        view.addSubview(rectangleImage!);
        
        let panRecognizer = UIPanGestureRecognizer()
        
        panRecognizer.addTarget(self, action: (#selector(ViewController.handlePan(_:))))
        
        view.addGestureRecognizer(panRecognizer)
        
        timer = NSTimer.scheduledTimerWithTimeInterval(0.005, target: self, selector: #selector(runBall), userInfo: nil, repeats: true)
        
    }
    
    func runBall() {
        dispatch_async(dispatch_get_global_queue(DISPATCH_QUEUE_PRIORITY_BACKGROUND, 0), { () -> Void in
            var lost = false
            
            dispatch_async(dispatch_get_main_queue(), { () -> Void in
                if (self.ballImage!.center.y >= (self.rectangleImage!.center.y - self.rectangleImage!.bounds.size.height)
                    && self.ballImage!.center.x >= (self.rectangleImage!.center.x - self.rectangleImage!.bounds.size.width/2)
                    && self.ballImage!.center.x <= (self.rectangleImage!.center.x + self.rectangleImage!.bounds.size.width/2))
                {
                    self.directionY = -1;
                }
                
                if (self.ballImage!.center.x >= self.view.bounds.size.width - self.ballImage!.bounds.size.width/2
                    || self.ballImage!.center.x <= 0)
                {
                    self.directionX *= -1;
                }
                
                if (self.ballImage!.center.y >= self.view.bounds.size.height - self.ballImage!.bounds.size.height/2)
                {
                    lost = true;
                }
                
                if (self.ballImage!.center.y <= 0)
                {
                    self.directionY *= -1;
                }
                
                self.ballImage!.center = CGPoint(x: self.ballImage!.center.x + self.directionX,
                    y: self.ballImage!.center.y + self.directionY);
                if lost
                {
                    let lostLabel = UILabel();
                    lostLabel.text = "YOU LOST!";
                    lostLabel.textColor = UIColor.redColor();
                    lostLabel.font = UIFont(name: "Helvetica-Bold", size: 20);
                    
                    lostLabel.frame = CGRect(origin: CGPoint(x: self.view.bounds.width * 0.35, y: self.view.bounds.height * 0.4),
                        size: CGSize(width: self.view.bounds.size.width, height: 100));
                    
                    self.view.addSubview(lostLabel);
                    
                    self.timer?.invalidate()
                }
            })
        })
    }
    
    @IBAction func handlePan(recognizer:UIPanGestureRecognizer) {
        let translation = recognizer.translationInView(self.view)
        
        moveRect(translation.x)
        
        recognizer.setTranslation(CGPointZero, inView: self.view)
    }
    
    func moveRect(x: CGFloat)
    {
        if (rectangleImage!.center.x+x>=0 && rectangleImage!.center.x+x<=view.bounds.width)
        {
            rectangleImage!.center = CGPoint(x: rectangleImage!.center.x+x, y: rectangleImage!.center.y)
        }
    }
}

