import { Injectable } from "@angular/core";
import Plausible from "plausible-tracker";

@Injectable({
  providedIn: 'root'
})
export class PlausibleService {

  trackPageview = Plausible().trackPageview;

  trackEvent = Plausible().trackEvent;
}
