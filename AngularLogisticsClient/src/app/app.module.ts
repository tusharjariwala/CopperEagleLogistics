import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { IndexComponent } from './client/index.component';
import { HeaderComponent } from './client/header.component';
import { ClientComponent } from './client/client.component';
import { FooterComponent } from './client/footer.component';
import { AboutusComponent } from './client/aboutus.component';
import { ServicesComponent } from './client/services.component';
import { ContactusComponent } from './client/contactus.component';
import { TeamComponent } from './client/team.component';
import { CompanyHistoryComponent } from './client/company-history.component';
import { OurClientsComponent } from './client/our-clients.component';
import { TestimonialsComponent } from './client/testimonials.component';
import { CareerComponent } from './client/career.component';
import { FaqComponent } from './client/faq.component';
import { TrackshipmentComponent } from './client/trackshipment.component';
import { RequestQuoteComponent } from './client/request-quote.component';
import { ThankYouComponent } from './client/thank-you.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './client/login.component';
import { AuthGuard } from './services/Auth.guard';
import { ProfileComponent } from './client/profile.component';
import { UserprofileComponent } from './client/userprofile.component';
import { LogoutComponent } from './client/logout.component';
import { OrderComponent } from './client/order.component';
import { ShowTrackingComponent } from './client/show-tracking.component';
import { SignupComponent } from './client/signup.component';

@NgModule({
  declarations: [
    AppComponent,
    IndexComponent,
    HeaderComponent,
    ClientComponent,
    FooterComponent,
    AboutusComponent,
    ServicesComponent,
    ContactusComponent,
    TeamComponent,
    CompanyHistoryComponent,
    OurClientsComponent,
    TestimonialsComponent,
    CareerComponent,
    FaqComponent,
    TrackshipmentComponent,
    RequestQuoteComponent,
    ThankYouComponent,
    LoginComponent,
    ProfileComponent,
    UserprofileComponent,
    LogoutComponent,
    OrderComponent,
    ShowTrackingComponent,
    SignupComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
  ],
  providers: [AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
