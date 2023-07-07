import { Routes } from '@angular/router';
import { PermissionAuthorizeService } from 'src/modules/common-shared';
import {
  FullLayoutComponent,
} from 'src/app/conteiners/full-layout/full-layout/full-layout.component';
// SimpleLayoutComponent,
// ForgotPasswordComponent,
// LoginComponent,
// LogoutComponent,
// MyProfileComponent,
// ResetPasswordComponent,
// UnauthorizeComponent,
export const ROUTES: Routes = [
  {
    path: '',
    component: FullLayoutComponent,
    children: [
      {
        path: '',
        redirectTo: '/exams/summary',
        pathMatch: 'full'
      },
      {
        path: 'exams',
        // canActivate: [PermissionAuthorizeService],
        //loadChildren: () => import('../modules/exam-module/exams.module').then(m => m.ExamsModule),
        data: {
          // permissions: [
          //   'MagViewPermissions.Dashboard.Overview',
          //   'MagViewPermissions.Dashboard.Activity',
          //   'MagViewPermissions.Attestation.View',
          //   'MagViewPermissions.Dashboard.Alerts'
          // ]
        },
        canActivate: [PermissionAuthorizeService],
      },
      {
        path: 'outcomes',
        //loadChildren: () => import('../modules/outcomes-module/outcomes.module').then(m => m.OutcomesModule),
        canActivate: [PermissionAuthorizeService],
        data: {
          title: 'Outcomes'
        },
      },
      {
        path: 'membership',
        //loadChildren: () => import('../modules/membership-module/membership.module').then(m => m.MembershipModule),
        canActivate: [PermissionAuthorizeService],
        data: {
          title: 'Membership'
        }
      },
      {
        path: 'widgets',
        //loadChildren: () => import('../modules/widget-module/widget.module').then(m => m.WidgetModule),
        data: {
          // permissions: [
          //   'MagViewPermissions.Dashboard.Overview',
          //   'MagViewPermissions.Dashboard.Activity',
          //   'MagViewPermissions.Attestation.View',
          //   'MagViewPermissions.Dashboard.Alerts'
          // ]
        },
        canActivate: [PermissionAuthorizeService],
      },
      {
        path: 'my-profile',
      //  component: MyProfileComponent,
       // canActivate: [PermissionAuthorizeService],
        data: {
          title: 'My Profile'
        }
      },
      {
        path: 'patients',
        data: {
          title: 'Patients'
        },
        //loadChildren: () => import('../modules/patients-module/patients.module').then(m => m.PatientsModule),
        canActivate: [PermissionAuthorizeService],
      },
      {
        path: 'unauthorized',
        canActivate: [PermissionAuthorizeService],
        //component: UnauthorizeComponent,
        data: {
          title: 'Unauthorized'
        }
      },
      {
        path: 'membership',
        canActivate: [PermissionAuthorizeService],
        //loadChildren: () => import('../modules/membership-module/membership.module').then(m => m.MembershipModule),
        data: {
          title: 'UserModel Management',
          permissions: ['MembershipPermissions.ManageUser']
        }
      },
      // {
      //   path: 'configuration',
      //   canActivate: [PermissionAuthorizeService],
      //   loadChildren: () => import('../modules/configuration-module/configuration.module').then(m => m.ConfigurationModule),
      //   data: {
      //     permissions: [
      //       'MembershipPermissions.ManageUser',
      //       'MagViewPermissions.Configuration.LocationsEdit',
      //       'MagViewPermissions.Configuration.ProceduresEdit',
      //       'MagViewPermissions.Configuration.InterfaceConfigEdit',
      //       'MagViewPermissions.Configuration.EmailAlertsEdit',
      //       'MagViewPermissions.Worklist.ConfigEdit',
      //       'MagViewPermissions.Gantry.ConfigEdit',
      //       'MagViewPermissions.Demo.ResetDb',
      //     ]
      //   }
      // },
      {
        path: 'site-settings',
        //loadChildren: () => import('../modules/site-settings-module/site-setting.module').then(m => m.SiteSettingModule),
        data: {
          title: 'Site Settings',
          permissions: [
            'SiteSettings.UpdateSettings'
          ]
        }
      },
      {
        path: 'security',
        //loadChildren: () => import('../modules/security-module/security.module').then(m => m.SecurityModule),
        data: {
          title: 'Security Settings',
          permissions: [
            'LuminaryOne.SecuritySettings.UpdateSettings'
          ]
        }
      }
    ]
  },
  {
    path: 'pdf',
    children: [
      {
        path: 'exams',
        //loadChildren: () => import('../modules/exams-pdf-module/exams-pdf.module').then(m => m.ExamPdfModule),
      },
      {
        path: 'metrics',
        //loadChildren: () => import('../modules/widget-pdf-module/widget-pdf.module').then(m => m.WidgetPdfModule),
      },
      {
        path: 'outcomes',
        //loadChildren: () => import('../modules/outcomes-module/outcomes.module').then(m => m.OutcomesModule),
      },
      {
        path: 'patients',
        //loadChildren: () => import('../modules/patients-module/patients.module').then(m => m.PatientsModule),
      }
    ]
  },
  {
    path: 'login',
    //component: SimpleLayoutComponent,
    children: [
      {
        path: '',
    //    component: LoginComponent
      }
    ],
    data: {
      title: 'Login'
    }
  },
  {
    path: 'forgotpassword',
    // component: SimpleLayoutComponent,
    children: [
      {
        path: '',
        // component: ForgotPasswordComponent
      }
    ],
    data: {
      title: 'Forgot Password'
    }
  },
  {
    path: 'setuppassword/:token',
    //component: SimpleLayoutComponent,
    children: [
      {
        path: '',
        //    component: ResetPasswordComponent
      }
    ],
    data: {
      title: 'Setup Password',
      isPasswordSetup: true
    },
  },
  {
    path: 'resetpassword/:token',
    //component: SimpleLayoutComponent,
    children: [
      {
        path: '',
     //   component: ResetPasswordComponent
      }
    ],
    data: {
      title: 'Reset Password'
    }
  },
  {
    path: 'logout',
    //component: SimpleLayoutComponent,
    children: [
      {
        path: '',
     //   component: LogoutComponent
      }
    ],
    data: {
      title: 'Logout'
    }
  },
  {
    path: '**',
    redirectTo: '/exams/summary',
    pathMatch: 'full',
  }
];
