// ---------------------------------------------------
// Demo 1: https://quickapp-pro.azurewebsites.net
// Demo 2: https://quickapp-standard.azurewebsites.net
//
// --> Gun4Hire: contact@ebenmonney.com
// ---------------------------------------------------

import {Directive, ElementRef, EventEmitter, NgZone, OnDestroy, Output} from '@angular/core';
import {fromEvent, Subscription} from 'rxjs';

declare let bootstrap: {
  Tab: {
    getOrCreateInstance: (arg: string) => { show: () => void }
  }
}

export interface EventArg {
  type: string;
  target: Element;
  relatedTarget: Element;
}

@Directive({
  selector: '[appBootstrapTab]',
  exportAs: 'bootstrap-tab'
})
export class BootstrapTabDirective implements OnDestroy {
  @Output()
  showBSTab = new EventEmitter<EventArg>();

  @Output()
  hideBSTab = new EventEmitter<EventArg>();

  private tabShownSubscription: Subscription;
  private tabHiddenSubscription: Subscription;

  constructor(private el: ElementRef, private zone: NgZone) {
    this.tabShownSubscription = fromEvent(this.el.nativeElement, 'show.bs.tab')
      .subscribe(e => {
        const arg = e as EventArg;
        this.runInZone(() => this.showBSTab.emit({
          type: arg.type,
          target: arg.target,
          relatedTarget: arg.relatedTarget
        }));
      });

    this.tabHiddenSubscription = fromEvent(this.el.nativeElement, 'hidden.bs.tab')
      .subscribe(e => {
        const arg = e as EventArg;
        this.runInZone(() => this.hideBSTab.emit({
          type: arg.type,
          target: arg.target,
          relatedTarget: arg.relatedTarget
        }));
      });
  }

  ngOnDestroy() {
    this.tabShownSubscription.unsubscribe();
    this.tabHiddenSubscription.unsubscribe();
  }

  show(selector: string) {
    const tab = bootstrap.Tab.getOrCreateInstance(selector);
    setTimeout(() => tab.show());
  }

  private runInZone(delegate: () => void) {
    this.zone.run(() => {
      delegate();
    });
  }
}
