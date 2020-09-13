import { Directive, Input, HostListener, OnInit, ComponentRef, ElementRef } from "@angular/core";
import { Overlay, OverlayRef, OverlayPositionBuilder } from "@angular/cdk/overlay";
import { ComponentPortal } from "@angular/cdk/portal";
import { TooltipComponent } from "../entry-components/TooltipComponent";

@Directive({ selector: '[tooltip]' })
export class TooltipDirective implements OnInit {

  @Input('tooltip') text: string = '';

  overlayRef: OverlayRef;

  constructor(
    private overlay: Overlay,
    private overlayPositionBuilder: OverlayPositionBuilder,
    private elementRef: ElementRef) {}

  ngOnInit() {

    const positionStrategy = this.overlayPositionBuilder
      .flexibleConnectedTo(this.elementRef)
      .withPositions([{
        originX: 'center',
        originY: 'top',
        overlayX: 'center',
        overlayY: 'bottom',
      }]);

    this.overlayRef = this.overlay.create({ positionStrategy });
  }

  @HostListener('mouseenter')
  show() {

    const toolTipPortal = new ComponentPortal(TooltipComponent);

    const toolTipRef: ComponentRef<TooltipComponent> = this.overlayRef.attach(toolTipPortal);

    toolTipRef.instance.text = this.text;

  }

  @HostListener('mouseout')
  hide() {

    this.overlayRef.detach();

  }


}
