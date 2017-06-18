package
{
   import flash.display.Sprite;
   import flash.display3D.Context3D;
   import flash.display3D.Context3DProfile;
   import flash.display3D.Context3DRenderMode;
   import flash.events.Event;
   import flash.external.ExternalInterface;
   import flash.system.Capabilities;
   
   public class Main extends Sprite
   {
       
      
      public var c3D:Context3D;
      
      public var olderPlayer:Boolean;
      
      public var display:Boolean;
      
      public var baselineSupported:Boolean;
      
      public var constrainedSupported:Boolean;
      
      public var baselineDriverInfo:String;
      
      public var constrainedDriverInfo:String;
      
      public function Main()
      {
         super();
         if(stage)
         {
            this.init();
         }
         else
         {
            addEventListener(Event.ADDED_TO_STAGE,this.init);
         }
      }
      
      public function getCurrentSystemLanguage() : void
      {
         ExternalInterface.call("saveFromFlash","{\"name\":\"currentSystemLanguage\",\"data\":\"" + Capabilities.language + "\"}");
      }
      
      public function getInstalledFlashVersion() : void
      {
         ExternalInterface.call("saveFromFlash","{\"name\":\"installedFlashVersion\", \"data\":\"" + Capabilities.version.split(" ")[1].split(",").join(".") + "\"}");
      }
      
      private function init(e:Event = null) : void
      {
         ExternalInterface.addCallback("getCurrentSystemLanguage",this.getCurrentSystemLanguage);
         ExternalInterface.addCallback("getInstalledFlashVersion",this.getInstalledFlashVersion);
         ExternalInterface.call("console.log",Capabilities.playerType);
         removeEventListener(Event.ADDED_TO_STAGE,this.init);
         this.olderPlayer = false;
         this.display = false;
         this.baselineSupported = false;
         this.constrainedSupported = false;
         this.baselineDriverInfo = "";
         this.constrainedDriverInfo = "";
         stage.stage3Ds[0].addEventListener(Event.CONTEXT3D_CREATE,this.stageNotificationHandler);
         try
         {
            trace("2");
            stage.stage3Ds[0].requestContext3D(Context3DRenderMode.AUTO,Context3DProfile.BASELINE);
         }
         catch(e:Error)
         {
            olderPlayer = true;
            stage.stage3Ds[0].removeEventListener(Event.CONTEXT3D_CREATE,stageNotificationHandler);
            stage.stage3Ds[0].addEventListener(Event.CONTEXT3D_CREATE,oldPlayerStageNotificationHandler);
            stage.stage3Ds[0].requestContext3D(Context3DRenderMode.AUTO);
         }
      }
      
      public function stageNotificationHandler(e:Event = null) : void
      {
         var t:String = null;
         trace("3");
         stage.stage3Ds[0].context3D.removeEventListener(Event.CONTEXT3D_CREATE,this.stageNotificationHandler);
         this.c3D = stage.stage3Ds[0].context3D;
         if(this.c3D.driverInfo.toLowerCase().indexOf("baseline constrained") > -1)
         {
            if(this.c3D.driverInfo.toLowerCase().indexOf(Context3DRenderMode.SOFTWARE) == -1)
            {
               this.constrainedSupported = true;
            }
            this.constrainedDriverInfo = this.c3D.driverInfo;
         }
         else
         {
            if(this.c3D.driverInfo.toLowerCase().indexOf(Context3DRenderMode.SOFTWARE) == -1)
            {
               this.baselineSupported = true;
            }
            this.baselineDriverInfo = this.c3D.driverInfo;
         }
         if(this.display)
         {
            t = "{\"mode\":\"normal\"," + "\"baselineDriverInfo\":\"" + this.baselineDriverInfo + "\",\"constrainedDriverInfo\":\"" + this.constrainedDriverInfo + "\",\"baselineSupported\":" + this.baselineSupported + ",\"constrainedSupported\":" + this.constrainedSupported + "}";
            this.c3D.configureBackBuffer(stage.stageWidth,stage.stageHeight,4,false);
            ExternalInterface.call("saveFromFlash","{\"name\":\"haSupport\",\"data\":" + t + "}");
            ExternalInterface.call("flashReady");
         }
         if(!this.display)
         {
            this.display = true;
            try
            {
               stage.stage3Ds[0].requestContext3D(Context3DRenderMode.AUTO,Context3DProfile.BASELINE_CONSTRAINED);
            }
            catch(e:Error)
            {
               return;
            }
         }
      }
      
      public function oldPlayerStageNotificationHandler(e:Event) : void
      {
         stage.stage3Ds[0].context3D.removeEventListener(Event.CONTEXT3D_CREATE,this.oldPlayerStageNotificationHandler);
         this.c3D = stage.stage3Ds[0].context3D;
         var t:String = Boolean("{\"mode\":\"old\"," + "\"baselineSupported\":" + (this.c3D.driverInfo.toLowerCase().indexOf(Context3DRenderMode.SOFTWARE) == -1))?"true":"false" + ",\"renderMode\":" + this.c3D.driverInfo + "}";
         this.c3D.configureBackBuffer(stage.stageWidth,stage.stageHeight,4,false);
         ExternalInterface.call("saveFromFlash","{\"name\":\"haSupport\",\"data\":" + t + "}");
         ExternalInterface.call("flashReady");
      }
   }
}
