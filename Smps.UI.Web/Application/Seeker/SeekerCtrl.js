(function () {
    angular.module('SMPSapp')
               .controller('SeekerCtrl', ['$scope', '$rootScope', '$http', 'userAccountService', 'auth', '$window', '$state', SeekerCtrl]);
    //This controller method instantiation of holder user info i.e holder info for the CRUD operation.
    /*This controller method instantiation of holder user info i.e holder info for the CRUD operation.*/
    /*Control method start*/
    function SeekerCtrl($scope, $rootScope, $http, userAccountService, auth, $window, $state) {
        debugger;
        $scope.isReleased = false;
        $scope.userProfile = auth;
       

        //if ($scope.userProfile.UserType == 'Seeker') {
        //    debugger;
        //    /*flag to display seeker page info*/
        //    $scope.isReleased = true;
        //    $scope.seekerMessage = 'Seeker page under construction';
        //}
        // The below method will fetches the user data to populate on the views.
        /*The below method will fetches the user data to populate on the views.*/
        $scope.RequestSlot = function () {
            debugger;
            $http({
                method: 'GET',
                url: $rootScope.apiURL + 'useraccount/RequestSlot?Empno=' + $scope.userProfile.EmpNo
            }).then(function (response) {
                debugger;
                alert(response.data);

            }, function () {
                alert("sucess");
                $scope.userProfile = 'No data found for specified user';
            });
        };
        //This function is relase the slot based on the request
        /*This function is relase the slot based on the request*/
        $scope.releaseSlotoutput = function (holder) {
            /*holder code for relasing slot*/



            debugger;
            $http({
                method: 'Post',
                url: $rootScope.apiURL + 'useraccount/Releaseslot',
                data: JSON.stringify(holder),
                headers: { 'Content-Type': 'application/json' }
            }).then(function () {
                debugger;
                alert("sucess");
                $scope.isReleased = true;
                $scope.successMessage = 'Thank you!! Slot released successfully';
            }, function () {
                debugger;
                $state.go('HolderErrorpage');
                //alert("Sorry Your Slot Already released");
                //$scope.Noneedto = true;
                //$scope.userProfile = 'No data found for specified user';
            });



            /*condition to display success message*/

        };
    }
}());
// End of holder controller.
/*End of holder controller.*/
