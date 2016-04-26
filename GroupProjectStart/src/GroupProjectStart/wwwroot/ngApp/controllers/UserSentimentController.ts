namespace GroupProjectStart.Controllers {
    export class UserSentimentController {

        public sentimentData: any;
        public userComment: string;
        private sentimentResource: any;


        constructor(private $resource: angular.resource.IResourceService) {
            this.sentimentResource = this.$resource("/api/sentiment/:sampletext");           
        }

        public getsentimentdata() {
            this.sentimentData = this.sentimentResource.query({ sampletext: this.userComment });
        }
    }
}