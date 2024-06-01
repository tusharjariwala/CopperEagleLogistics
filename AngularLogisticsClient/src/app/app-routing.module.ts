import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutusComponent } from './client/aboutus.component';
import { CareerComponent } from './client/career.component';
import { ClientComponent } from './client/client.component';
import { CompanyHistoryComponent } from './client/company-history.component';
import { ContactusComponent } from './client/contactus.component';
import { FaqComponent } from './client/faq.component';
import { IndexComponent } from './client/index.component';
import { LoginComponent } from './client/login.component';
import { LogoutComponent } from './client/logout.component';
import { OrderComponent } from './client/order.component';
import { OurClientsComponent } from './client/our-clients.component';
import { ProfileComponent } from './client/profile.component';
import { RequestQuoteComponent } from './client/request-quote.component';
import { ServicesComponent } from './client/services.component';
import { ShowTrackingComponent } from './client/show-tracking.component';
import { SignupComponent } from './client/signup.component';
import { TeamComponent } from './client/team.component';
import { TestimonialsComponent } from './client/testimonials.component';
import { ThankYouComponent } from './client/thank-you.component';
import { TrackshipmentComponent } from './client/trackshipment.component';
import { UserprofileComponent } from './client/userprofile.component';
import { AuthGuard } from './services/Auth.guard';

const routes: Routes = [
  {
    path: '', redirectTo: '/client', pathMatch: 'full'
  },
  {
    path: 'client', component: ClientComponent, children: [
      { path: '', component: IndexComponent, runGuardsAndResolvers: "always", },
      { path: 'aboutus', component: AboutusComponent, runGuardsAndResolvers: "always", },
      { path: 'services', component: ServicesComponent, runGuardsAndResolvers: "always", },
      { path: 'contactus', component: ContactusComponent, runGuardsAndResolvers: "always", },
      { path: 'team', component: TeamComponent, runGuardsAndResolvers: "always", },
      { path: 'company-history', component: CompanyHistoryComponent, runGuardsAndResolvers: "always", },
      { path: 'our-clients', component: OurClientsComponent, runGuardsAndResolvers: "always", },
      { path: 'testimonials', component: TestimonialsComponent, runGuardsAndResolvers: "always", },
      { path: 'career', component: CareerComponent, runGuardsAndResolvers: "always", },
      { path: 'faq', component: FaqComponent, runGuardsAndResolvers: "always", },
      { path: 'trackshipment', component: TrackshipmentComponent, runGuardsAndResolvers: "always", },
      { path: 'request-quote', component: RequestQuoteComponent, runGuardsAndResolvers: "always", },
      { path: 'thank-you', component: ThankYouComponent, runGuardsAndResolvers: "always", },
      { path: 'login', component: LoginComponent, runGuardsAndResolvers: "always", },
      { path: 'profile', component: ProfileComponent, runGuardsAndResolvers: "always", },
      { path: 'userprofile', component: UserprofileComponent, runGuardsAndResolvers: "always", },
      { path: 'logout', component: LogoutComponent, runGuardsAndResolvers: "always", },
      { path: 'order', component: OrderComponent, runGuardsAndResolvers: "always", },
      { path: 'show-tracking/:id', component: ShowTrackingComponent, runGuardsAndResolvers: "always", },
      { path: 'signup', component: SignupComponent, runGuardsAndResolvers: "always", }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { onSameUrlNavigation: 'reload' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
