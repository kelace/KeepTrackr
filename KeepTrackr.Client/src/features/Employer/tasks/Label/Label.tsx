import React, { ChangeEvent  } from "react";
import { useSelector } from 'react-redux';
import { useRef } from "react";
import { useState } from "react";
import { Check, X } from "react-feather";
import "./Label.css";
import { ColorResult, SketchPicker } from 'react-color';
import { changeColor, changeNewLabelName, createLabel } from '../tasksPageSlice';
import { useDispatch } from "react-redux";
import { AppDispatch } from '../../../../app/store';

export default function (props: any) {
    const input = useRef<HTMLInputElement>(null);

    const [selectedColor, setSelectedColor] = useState("");

    const [label, setLabel] = useState("");

    const labels = useSelector((x: any) => x.tasks.labels.entities);

    const newLabelName = useSelector((x: any) => x.tasks.newLabelName);

    const dispatch = useDispatch<AppDispatch>();

    //const isColorUsed = useSelector((x: any) => {
    //    const isFound =labelsfind((item: any) => item.color === color);
    //    return isFound ? true : false;
    //});

    const cardId = useSelector((x: any) => x.tasks.openedCardId); 

    const defaultColor = useSelector((x: any) => x.tasks.color);

    const isColorUsed = (color: any) => {

        const isFound = labels.find((item: any) => item.color === color);

        return isFound ? true : false;
    };

    return (
        <div className="local__bootstrap">
            <div className="popover__wrapper">
                <div className="popover__content mb-2">
                    <div className="label__heading d-flex justify-content-between my-2 ">
                        <p style={{ fontSize: "15px" }} className="text-center">
                            <b>Label</b>
                        </p>
                        <X
                            onClick={() => props.onClose(false)}
                            style={{
                                cursor: "pointer", width: "15px", height: "15px", position: "absolute",
                                top: "10px",
                                right: "10px" }}
                        />
                    </div>
                    <div className="row">
                        <p
                            style={{
                                color: "#5e6c84",
                                display: "block",
                                fontSize: "12px",
                                fontWeight: "700",
                                lineHeight: "16px",
                            }}
                            className="my-1"
                        >
                            Name
                        </p>

                        <div className="col-12 label__input">
                            <input
                                type="text"
                                ref={input}
                                value={newLabelName}
                                placeholder="Name of label"
                                onChange={(e: any) => {
                                    dispatch(changeNewLabelName(e.target.value));
                                }}
                            />

                        </div>
                        <p
                            style={{
                                color: "#5e6c84",
                                display: "block",
                                fontSize: "12px",
                                fontWeight: "700",
                                lineHeight: "16px",
                            }}
                            className="my-2"
                        >
                            Select color
                        </p>
                        <div className="d-flex justify-content-between color__palette flex-wrap mb-2">
                            <SketchPicker color={defaultColor} onChange={(x: any) => dispatch(changeColor(x))} />
                            {/*{props.color.map((item: any, index: any) => (*/}
                            {/*    <span*/}
                            {/*        onClick={() => setSelectedColor(item)}*/}
                            {/*        key={index}*/}
                            {/*        className={isColorUsed(item) ? "disabled__color" : ""}*/}
                            {/*        style={{ backgroundColor: item, cursor: "pointer" }}*/}
                            {/*    >*/}
                            {/*        {selectedColor === item ? <Check className="icon__sm" /> : ""}*/}
                            {/*    </span>*/}
                            {/*))}*/}
                        </div>
                        <div>
                            <button
                                className="create__btn my-2"
                                onClick={() => dispatch(createLabel({
                                    title: newLabelName, color: defaultColor.hex, cardId
                                }))}>
                                Create
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}
